using InitialProject.Domain.Models;
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

        private VoucherRepository _voucherRepository;
        public VoucherService()
        {
            _voucherRepository = VoucherRepository.GetInstance();

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



    }
}
