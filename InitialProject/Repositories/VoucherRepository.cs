using InitialProject.Domain.Models;

using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repositories
{
    public class VoucherRepository
    {
        private const string FilePath = "../../../Resources/Data/vouchers.csv";

        private static VoucherRepository instance = null;

        private readonly Serializer<Voucher> _serializer;

        private List<Voucher> _vouchers;

        private VoucherRepository()
        {

            _serializer = new Serializer<Voucher>();
            _vouchers = _serializer.FromCSV(FilePath);
        }

        public static VoucherRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new VoucherRepository();
            }
            return instance;
        }

        public int NextId()
        {
            
            if (_vouchers.Count < 1)
            {
                return 1;
            }
            return _vouchers.Max(t => t.Id) + 1;
        }

        public Voucher Save(Voucher voucher)
        {
            voucher.Id = NextId();
            _vouchers.Add(voucher);
            _serializer.ToCSV(FilePath, _vouchers);
            return voucher;

        }

      
        public Voucher Update(Voucher voucher)
        {
            
            Voucher current = _vouchers.Find(v => v.Id == voucher.Id);
            int index = _vouchers.IndexOf(current);
            _vouchers.Remove(current);
            _vouchers.Insert(index, voucher);
            _serializer.ToCSV(FilePath, _vouchers);
            return voucher;
        }

        public void BindVoucherUser()
        {
            foreach (Voucher voucher in _vouchers)
            {
                int userId = voucher.User.Id;
                User user = UserRepository.GetInstance().Get(userId);
                if (user != null)
                {
                    voucher.User = user;
                   
                }
                else
                {
                    Console.WriteLine("Error in VoucherUser binding");
                }
            }
        }
    }
}
