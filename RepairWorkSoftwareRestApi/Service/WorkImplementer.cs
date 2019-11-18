using System;
using System.Threading;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;

namespace RepairWorkSoftwareRestApi.Service
{
    public class WorkImplementer
    {
        private readonly IMainService _mainService;

        private readonly IImplementerService _implementerService;

        private readonly int _implementerId;

        private readonly int _orderId;
        
        static readonly Semaphore _semaphore = new Semaphore(3, 3);

        private readonly  Thread myThread;

        public WorkImplementer(
            IMainService mainService,
            IImplementerService implementerService,
            int implementerId,
            int orderId)
        {
            _mainService = mainService;
            _implementerService = implementerService;
            _implementerId = implementerId;
            _orderId = orderId;

            try
            {
                _mainService.TakeOrderInWork(new OrderBindingModel
                {
                    Id = _orderId,
                    ImplementerId = _implementerId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            myThread = new Thread(Work);
            myThread.Start();
        }

        public void Work()
        {
            try
            {
                _semaphore.WaitOne();

                Thread.Sleep(10000);
                _mainService.FinishOrder(new OrderBindingModel
                {
                    Id = _orderId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}