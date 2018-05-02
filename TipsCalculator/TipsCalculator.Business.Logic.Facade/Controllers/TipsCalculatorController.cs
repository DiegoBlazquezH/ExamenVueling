using System.Threading.Tasks;
using System.Web.Http;
using TipsCalculator.DataAccess.Logic;
using TipsCalculator.Business.Logic;

namespace TipsCalculator.Business.Logic.Facade.Controllers
{
    public class TipsCalculatorController : ApiController
    {
        private readonly ITipsLogic TipsLogic;

        public TipsCalculatorController(ITipsLogic tipsLogic)
        {
            TipsLogic = tipsLogic;
        }

        /// <summary>
        /// Devuelve las conversiones recibidas del WebService inicial
        /// </summary>
        /// <returns>List&lt;Conversion&gt;</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetConversions()
        {
            var result = await this.TipsLogic.GetConversions();
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Devuelve los pedidos recibidos del WebService inicial
        /// </summary>
        /// <returns>List&lt;Order&gt;</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetOrders()
        {
            var result = await this.TipsLogic.GetOrders();
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Devuelve los pedidos con la propina correspondiente
        /// </summary>
        /// <param name="tip"></param>
        /// <returns>List&lt;OrderWithTip&gt;</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetOrdersWithTips(int tip)
        {
            var result = await this.TipsLogic.GetOrdersTips(tip);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
