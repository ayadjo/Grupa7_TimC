using InitialProject.Domain.Models;
using InitialProject.Domain.RepositoryInterfaces;
using InitialProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service.Services
{
    public class VoucherService
    {

        private IVoucherRepository _voucherRepository;
        public VoucherService()
        {
            _voucherRepository = Injector.Injector.CreateInstance<IVoucherRepository>();
        }

        public List<Voucher> GetAll()
        {
            return _voucherRepository.GetAll();
        }
        public Voucher Get(int id)
        {

            return _voucherRepository.Get(id);

        }

        public Voucher Save(Voucher voucher)
        {

            return _voucherRepository.Save(voucher);
        }


        public Voucher Update(Voucher voucher)
        {
            return _voucherRepository.Update(voucher);
        }

        public void Delete(Voucher voucher)
        {

            _voucherRepository.Delete(voucher);

        }

        public List<Voucher> GetVouchersThatDidntExpire()
        {
            List<Voucher> voucherList = new List<Voucher>();
            var allVouchers = _voucherRepository.GetAll();
            for (int i = 0; i < allVouchers.Count(); i++)
            {
                var voucher = allVouchers.ElementAt(i);
                if (voucher.ExpirationDate >= DateTime.Now)
                {
                    voucherList.Add(voucher);
                }
                else
                {
                    //ako vaucer nije iskoristen
                    var unusedVouchers = GetVouchersThatArentUsed(allVouchers);
                    if(voucher.ExpirationDate >= DateTime.Now) 
                    {
                        foreach (Voucher unusedVoucher in unusedVouchers)
                        {
                            _voucherRepository.Delete(unusedVoucher);
                        }
                    }

                }
            }
            return voucherList;
        }

        public List<Voucher> GetVouchersThatArentUsed(List<Voucher> vouchers)
        {
            List<Voucher> voucherList = new List<Voucher>();
            foreach (Voucher voucher in vouchers)
            {
                if (voucher.Used == false)
                {
                    voucherList.Add(voucher);
                }
            }
            return voucherList;
        }


        public List<Voucher> VoucherForUser(int userId)
        {
            List<Voucher> vouchers = new List<Voucher>();
            var validVouchers = GetVouchersThatDidntExpire();
            var unusedValidVouchers = GetVouchersThatArentUsed(validVouchers);
            foreach (Voucher voucher in unusedValidVouchers)
            {
                if (voucher.User.Id == userId)
                {
                    vouchers.Add(voucher);
                }
            }
            return vouchers;
        }


    }
}
