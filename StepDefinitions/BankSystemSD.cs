using CodeAssignment_QA_AjayAL.Models;
using CodeAssignment_QA_AjayAL.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace CodeAssignment_QA_AjayAL.StepDefinitions
{
    [Binding]
    public class BankSystemSD
    {
        RequestDetails apiRequestDetails;
        RestResponse restResponse;
        AccountDetails accountDetailsResponse;

        public BankSystemSD()
        {
            apiRequestDetails = new RequestDetails();
        }

        [Given(@"Account Initial Balance is \$(.*)")]
        public void SetInitialBalanceValue(int initBalance)
        {
             apiRequestDetails.InitialBalance = initBalance;
        }

        [Given(@"Account name is ""([^""]*)""")]
        public void SetAccountNameValue(string accName)
        {
            apiRequestDetails.AccountName = accName;
        }

        [Given(@"Address is ""([^""]*)""")]
        public void SetAddressValue(string address)
        {
            apiRequestDetails.Address = address;
        }

        [When(@"POST endpoint triggered to create new account with above details")]
        public void CreateNewAccount()
        {
            restResponse = APISetup.PostApiRequest(apiRequestDetails);
        }

        [Then(@"Verify the response code is (.*)")]
        public void VerifyResponseCode(int statusCode)
        {
            Assert.IsNotNull(restResponse, "Response object is NULL");
            Assert.True(restResponse.StatusCode.Equals(statusCode), "Expected Response status code is " + statusCode + ", But actual status code is " + restResponse.StatusCode);
        }

        [Then(@"Verify no error is returned")]
        public void VerifyNoErrorMessage()
        {
            accountDetailsResponse = JsonConvert.DeserializeObject<AccountDetails>(restResponse.Content);
            Assert.IsNotNull(accountDetailsResponse.Errors, "Errors details not available in response body");
            Assert.IsTrue(accountDetailsResponse.Errors.Length == 0, "Errors should be empty array but has values");
        }

        [Then(@"Verify the success message ""([^""]*)""")]
        public void VerifyTheSuccessMessage(string message)
        {
            accountDetailsResponse = JsonConvert.DeserializeObject<AccountDetails>(restResponse.Content);
            Assert.AreEqual(message, accountDetailsResponse.Message, "Expected message:" + message + " is not matching with Actual message:" + accountDetailsResponse.Message);
        }

        [Then(@"Verify the account details are correctly returned in the JSON response")]
        public void VerifyAccountDetails()
        {
            accountDetailsResponse = JsonConvert.DeserializeObject<AccountDetails>(restResponse.Content);
            Assert.AreEqual(apiRequestDetails.InitialBalance, accountDetailsResponse.Data.NewBalance, "New Balance not matching. Expected:" + apiRequestDetails.InitialBalance + ", Actual:" + accountDetailsResponse.Data.NewBalance);
            Assert.AreEqual(apiRequestDetails.AccountName, accountDetailsResponse.Data.AccountName, "Accoount Name not matching. Expected:" + apiRequestDetails.AccountName + ", Actual:" + accountDetailsResponse.Data.AccountName);
            Assert.IsNotEmpty(accountDetailsResponse.Data.AccountNumber, "Account Number should not be empty");
        }

        [Given(@"Account number is ""([^""]*)""")]
        public void SetAccountNumber(string accountNumber)
        {
            apiRequestDetails.AccountNumber = accountNumber;
        }

        [When(@"DELETE endpoint triggered to delete the given account")]
        public void DeleteAccount()
        {
            restResponse = APISetup.DeleteApiRequest(apiRequestDetails.AccountNumber);
        }

        [Then(@"Verify JSON response for Account deletion")]
        public void VerifyDeleteResponse()
        {
            accountDetailsResponse = JsonConvert.DeserializeObject<AccountDetails>(restResponse.Content);
            Assert.IsNull(accountDetailsResponse.Data, "Data object should be NULL is response body");
        }

        [Given(@"Amount to be deposit/withdraw is \$(.*)")]
        public void SetAmountValue(double amount)
        {
            apiRequestDetails.Amount = amount;
        }

        [When(@"PUT endpoint triggered to deposit an amount into the given account details")]
        public void DepositAmountIntoAccount()
        {
            restResponse = APISetup.PutApiRequest(apiRequestDetails, "/deposit");
        }

        [Then(@"Verify JSON response for Deposit action")]
        public void VerifyDepositResponse()
        {
            accountDetailsResponse = JsonConvert.DeserializeObject<AccountDetails>(restResponse.Content);
            Assert.AreEqual(apiRequestDetails.AccountNumber, accountDetailsResponse.Data.AccountNumber, "AccountNumber not matching. Expected:" + apiRequestDetails.AccountNumber + ", Actual:" + accountDetailsResponse.Data.AccountNumber);
            Assert.True(apiRequestDetails.Amount <= accountDetailsResponse.Data.NewBalance, "New Balance should be greater than or equal to depositted amount");
        }

        [When(@"PUT endpoint triggered to withdraw an amount from the given account details")]
        public void WithdrawAmountFrmAccount()
        {
            restResponse = APISetup.PutApiRequest(apiRequestDetails, "/withdraw");
        }

        [Then(@"Verify JSON response for withdraw action")]
        public void VerifyWithdrawtResponse()
        {
            accountDetailsResponse = JsonConvert.DeserializeObject<AccountDetails>(restResponse.Content);
            Assert.AreEqual(apiRequestDetails.AccountNumber, accountDetailsResponse.Data.AccountID, "AccountNumber and AccountId not matching. Expected:" + apiRequestDetails.AccountNumber + ", Actual:" + accountDetailsResponse.Data.AccountID);
            Assert.IsNotNull(accountDetailsResponse.Data.NewBalance, "New Balance should not be NULL");
        }
    }
}
