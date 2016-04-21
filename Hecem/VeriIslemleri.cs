using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tftp.Net;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Hecem
{
    public class VeriIslemleri
    {
        private static AutoResetEvent TransferFinishedEvent = new AutoResetEvent(false);
        TftpClient client;

        public VeriIslemleri(string sunucu="localhost")
        {
            client = new TftpClient(sunucu);
        }

        public void Cek(string veri = "hecem.accdb")
        {
            var transfer = client.Download(veri);

            //Capture the events that may happen during the transfer
            transfer.OnProgress += new TftpProgressHandler(transfer_OnProgress);
            transfer.OnFinished += new TftpEventHandler(transfer_OnFinshed);
            transfer.OnError += new TftpErrorHandler(transfer_OnError);

            Stream stream = new MemoryStream();
            transfer.Start(stream);

            //Wait for the transfer to finish
            TransferFinishedEvent.WaitOne();
        }

        static void transfer_OnProgress(ITftpTransfer transfer, TftpTransferProgress progress)
        {
            Debug.WriteLine("Transfer running. Progress: " + progress);
        }

        static void transfer_OnError(ITftpTransfer transfer, TftpTransferError error)
        {
            Debug.WriteLine("Transfer failed: " + error);
            TransferFinishedEvent.Set();
        }

        static void transfer_OnFinshed(ITftpTransfer transfer)
        {
            Debug.WriteLine("Transfer succeeded.");
            TransferFinishedEvent.Set();
        }
    }
}
