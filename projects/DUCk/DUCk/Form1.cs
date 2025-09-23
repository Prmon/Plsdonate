using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUCk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const string GitHubDllUrl = "https://github.com/Prmon/Plsdonate/blob/main/MCentersLibrary.dll"; // URL to the DLL on GitHub

        // DLL Injection method
        private bool InjectDLL(int processID, string dllPath)
        {
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, processID);
            if (hProcess == IntPtr.Zero)
            {
                MessageBox.Show("Error opening process.");
                return false;
            }

            IntPtr allocMem = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)(dllPath.Length + 1), 0x3000, 0x40);
            if (allocMem == IntPtr.Zero)
            {
                MessageBox.Show("Error allocating memory.");
                CloseHandle(hProcess);
                return false;
            }

            // Convert DLL path to byte array
            byte[] dllPathBytes = System.Text.Encoding.ASCII.GetBytes(dllPath);

            if (!WriteProcessMemory(hProcess, allocMem, dllPathBytes, (uint)(dllPathBytes.Length + 1), out _))
            {
                MessageBox.Show("Error writing memory.");
                VirtualFreeEx(hProcess, allocMem, 0, 0x8000);
                CloseHandle(hProcess);
                return false;
            }

            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (loadLibraryAddr == IntPtr.Zero)
            {
                MessageBox.Show("Error finding LoadLibraryA.");
                VirtualFreeEx(hProcess, allocMem, 0, 0x8000);
                CloseHandle(hProcess);
                return false;
            }

            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, allocMem, 0, IntPtr.Zero);
            if (hThread == IntPtr.Zero)
            {
                MessageBox.Show("Error creating remote thread.");
                VirtualFreeEx(hProcess, allocMem, 0, 0x8000);
                CloseHandle(hProcess);
                return false;
            }

            WaitForSingleObject(hThread, 0xFFFFFFFF);
            VirtualFreeEx(hProcess, allocMem, 0, 0x8000);
            CloseHandle(hThread);
            CloseHandle(hProcess);

            return true;
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string tempDllPath = Path.Combine(Path.GetTempPath(), "Mcenterslibrary.dll");

            try
            {
                // Download DLL from GitHub
                await DownloadDllFromGitHub(GitHubDllUrl, tempDllPath);

                if (FindOrLaunchMinecraftUwp())
                    MessageBox.Show("Minecraft UWP found or launched.");

                // Find the target process
                Process[] processes = Process.GetProcessesByName("Minecraft.Windows.exe");
                if (processes.Length == 0)
                {
                    MessageBox.Show("Target process not found.");
                    return;
                }

                int processID = processes[0].Id;

                if (InjectDLL(processID, tempDllPath))
                {
                    MessageBox.Show("DLL injection successful!");
                }
                else
                {
                    MessageBox.Show("DLL injection failed.");
                }

                // Perform memory manipulation (changing a negative hex value example)
                ManipulateMemory(processID);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Example of memory manipulation (changing a negative hex value)
        private void ManipulateMemory(int processID)
        {
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, processID);
            if (hProcess == IntPtr.Zero)
            {
                MessageBox.Show("Error opening process.");
                return;
            }

            // Example negative value address (replace with actual address or RVA)
            IntPtr targetAddress = (IntPtr)(0x8797425); // Replace with actual address

            // Read the current value (negative value example)
            int originalValue = ReadMemory<int>(hProcess, targetAddress);
            MessageBox.Show($"Original Value: {originalValue}");

            // Change to a new negative value (or positive if needed)
            int newValue = 132; // Example negative value to write
            WriteMemory(hProcess, targetAddress, newValue);

            // Confirm the modification
            int updatedValue = ReadMemory<int>(hProcess, targetAddress);
            MessageBox.Show($"Updated Value: {updatedValue}");

            CloseHandle(hProcess);
        }

        // Memory reading helper function for signed integer (can handle negative)
        private T ReadMemory<T>(IntPtr hProcess, IntPtr address)
        {
            int bytesRead;
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];

            if (ReadProcessMemory(hProcess, address, buffer, (uint)buffer.Length, out bytesRead))
            {
                if (typeof(T) == typeof(int))
                {
                    return (T)(object)BitConverter.ToInt32(buffer, 0); // Read as signed integer (int)
                }
                else if (typeof(T) == typeof(short))
                {
                    return (T)(object)BitConverter.ToInt16(buffer, 0); // Read as short
                }
                else if (typeof(T) == typeof(long))
                {
                    return (T)(object)BitConverter.ToInt64(buffer, 0); // Read as long
                }
                else
                {
                    throw new Exception("Unsupported type.");
                }
            }

            throw new Exception("Error reading memory.");
        }

        // Memory writing helper function for signed integer (can handle negative)
        private void WriteMemory(IntPtr hProcess, IntPtr address, int value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            if (!WriteProcessMemory(hProcess, address, buffer, (uint)buffer.Length, out _))
            {
                throw new Exception("Error writing memory.");
            }
        }

        // Download the DLL file from GitHub using HttpClient
        private async Task DownloadDllFromGitHub(string url, string localPath)
        {
            using (HttpClient client = new HttpClient())
            {
                byte[] dllBytes = await client.GetByteArrayAsync(url);
                File.WriteAllBytes(localPath, dllBytes);
            }
        }

        // Find and launch Minecraft UWP processes or try to start one if not running
        private bool FindOrLaunchMinecraftUwp()
        {
            // collect processes whose ProcessName contains "Minecraft.Windows" (case-insensitive)
            var processes = Process.GetProcesses();
            var matching = new System.Collections.Generic.List<Process>();

            foreach (var p in processes)
            {
                try
                {
                    if (p.ProcessName.IndexOf("Minecraft.Windows", StringComparison.OrdinalIgnoreCase) >= 0)
                        matching.Add(p);
                }
                catch
                {
                    // Ignore processes we don't have permission to inspect
                }
            }

            if (matching.Count > 0)
            {
                MessageBox.Show("Found Minecraft UWP process.");
                return true;
            }

            try
            {
                var startInfo = new ProcessStartInfo("explorer.exe", "minecraft://")
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process.Start(startInfo);
                MessageBox.Show("Launched Minecraft UWP.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching Minecraft: " + ex.Message);
                return false;
            }
        }


        private void Close1_Click(object sender, EventArgs e)
        {
            Environment.Exit(67);
        }

        #region P/Invoke declarations

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        #endregion
    }
}