using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Tftp.Net;
using System.Diagnostics;

namespace SunucuTarafi
{
    
    public class Islemler
    {
        private static String ServerDirectory;

        static WebServer ws = new WebServer(SendResponse, "http://" + GetComputer_LanIP() + ":8080/hecem/");
        public static void SunucuOlustur()
        {
           
            ws.Run();
            ResimveSeslerGonder();
          
        }
        public static string SendResponse(HttpListenerRequest request)
        {
            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }
        private static string GetComputer_LanIP()
        {
            string strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            foreach (IPAddress ipAddress in ipEntry.AddressList)
            {
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    return ipAddress.ToString();
                }
            }

            return "-";
        }

        public static void ResimveSeslerGonder()
        {
            ServerDirectory = Environment.CurrentDirectory;

            Debug.WriteLine("Running TFTP server for directory: " + ServerDirectory);

            using (var server = new TftpServer())
            {
                server.OnReadRequest += new TftpServerEventHandler(server_OnReadRequest);
                server.OnWriteRequest += new TftpServerEventHandler(server_OnWriteRequest);
                server.Start();
                
            }
        }




        static void server_OnWriteRequest(ITftpTransfer transfer, EndPoint client)
        {
            String file = Path.Combine(ServerDirectory, transfer.Filename);

            if (File.Exists(file))
            {
                CancelTransfer(transfer, TftpErrorPacket.FileAlreadyExists);
            }
            else
            {
                OutputTransferStatus(transfer, "Accepting write request from " + client);
                StartTransfer(transfer, new FileStream(file, FileMode.CreateNew));
            }
        }

        static void server_OnReadRequest(ITftpTransfer transfer, EndPoint client)
        {
            String path = Path.Combine(ServerDirectory, transfer.Filename);
            FileInfo file = new FileInfo(path);

            //Is the file within the server directory?
            if (!file.FullName.StartsWith(ServerDirectory, StringComparison.InvariantCultureIgnoreCase))
            {
                CancelTransfer(transfer, TftpErrorPacket.AccessViolation);
            }
            else if (!file.Exists)
            {
                CancelTransfer(transfer, TftpErrorPacket.FileNotFound);
            }
            else
            {
                OutputTransferStatus(transfer, "Accepting request from " + client);
                StartTransfer(transfer, new FileStream(file.FullName, FileMode.Open));
            }
        }

        private static void StartTransfer(ITftpTransfer transfer, Stream stream)
        {
            transfer.OnProgress += new TftpProgressHandler(transfer_OnProgress);
            transfer.OnError += new TftpErrorHandler(transfer_OnError);
            transfer.OnFinished += new TftpEventHandler(transfer_OnFinished);
            transfer.Start(stream);
        }

        private static void CancelTransfer(ITftpTransfer transfer, TftpErrorPacket reason)
        {
            OutputTransferStatus(transfer, "Cancelling transfer: " + reason.ErrorMessage);
            transfer.Cancel(reason);
        }

        static void transfer_OnError(ITftpTransfer transfer, TftpTransferError error)
        {
            OutputTransferStatus(transfer, "Error: " + error);
        }

        static void transfer_OnFinished(ITftpTransfer transfer)
        {
            OutputTransferStatus(transfer, "Finished");
        }

        static void transfer_OnProgress(ITftpTransfer transfer, TftpTransferProgress progress)
        {
            OutputTransferStatus(transfer, "Progress " + progress);
        }

        private static void OutputTransferStatus(ITftpTransfer transfer, string message)
        {
            Console.WriteLine("[" + transfer.Filename + "] " + message);
        }
    }
}
