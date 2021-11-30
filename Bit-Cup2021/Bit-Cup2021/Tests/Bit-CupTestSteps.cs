using Aquality.Selenium.Browsers;

namespace Bit_Cup2021
{
    public static class Bit_CupTestSteps
    {
        public static Form CreateAndWaitForFormDisplayed<Form>()
            where Form : Aquality.Selenium.Forms.Form, new()
        {
            AqualityServices.Logger.Info(nameof(CreateAndWaitForFormDisplayed));
            var form = new Form();
            form.State.WaitForDisplayed();
            return form;
        }
    }
}