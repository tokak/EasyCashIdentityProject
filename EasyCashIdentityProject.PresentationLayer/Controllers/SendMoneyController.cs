using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string mycurrency)
        {
            ViewBag.mycurrency = mycurrency;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            var context = new Context();
            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == 
            sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            var senderAccountNumberID = context.CustomerAccounts.Where(x=>x.AppUserID == user.Id).Where(y=>y.CustomerAccountCurrency=="Türk Lirası").Select(z=>z.CustomerAccountID).FirstOrDefault();

            //sendMoneyForCustomerAccountProcessDto.SenderID = user.Id;
            //sendMoneyForCustomerAccountProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //sendMoneyForCustomerAccountProcessDto.ProcessType = "Havale";
            //sendMoneyForCustomerAccountProcessDto.ReceiverID = receiverAccountNumberID;

            //Dto ile eşleştirme 
            var values = new CustomerAccountProcess()
            {
                ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                SenderID = senderAccountNumberID,
                Amount = sendMoneyForCustomerAccountProcessDto.Amount,
                ReceiverID = receiverAccountNumberID,
                ProcessType = "Havale",
                Description = sendMoneyForCustomerAccountProcessDto.Description,
                
            };

            _customerAccountProcessService.TInsert(values);

            return RedirectToAction("Index","Deneme");
        }

    }
}
