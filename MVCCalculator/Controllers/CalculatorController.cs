using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using MVCCalculator.Models;


namespace MVCCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel model)
        {
            switch (model.Operation)
            {
                case "Add":
                    model.Result = model.Number1 + model.Number2;
                    break;
                case "Subtract":
                    model.Result = model.Number1 - model.Number2;
                    break;
                case "Multiply":
                    model.Result = model.Number1 * model.Number2;
                    break;
                case "Divide":
                    if (model.Number2 != 0)
                        model.Result = model.Number1 / model.Number2;
                    else
                        ModelState.AddModelError("Number2", "Division by zero is not allowed.");
                    break;
                default:
                    ModelState.AddModelError("", "Invalid operation selected.");
                    break;
            }
            return View(model);
        }
    }
}
