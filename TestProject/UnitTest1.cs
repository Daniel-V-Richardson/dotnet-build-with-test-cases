using Jenkins_build;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void TestValidateName_Valid()
        {
            Register registrationForm = new Register();
            string validName = "Daniel";
            bool isValid = registrationForm.ValidateName(validName);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestValidateName_Invalid()
        {
            Register registrationForm = new Register();
            string invalidName = "123Dan";
            bool isValid = registrationForm.ValidateName(invalidName);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void TestValidateEmail_Valid()
        {
            Register registrationForm = new Register();
            string validEmail = "dan@gmail.com";
            bool isValid = registrationForm.ValidateEmail(validEmail);
            Assert.IsTrue(isValid);
        }
         [TestMethod]
        public void TestValidateEmail_Invalid()
        {
            Register registrationForm = new Register();
            string invalidEmail = "dan@gmail";
            bool isValid = registrationForm.ValidateEmail(invalidEmail);
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void TestValidatePhone_Valid()
        {
            Register registrationForm = new Register();
            string validPhone = "7007322396";
            bool isValid = registrationForm.ValidatePhoneNumber(validPhone);
            Assert.IsTrue(isValid);
        }
         [TestMethod]
        public void TestValidatePhone_Invalid()
        {
            Register registrationForm = new Register();
            string invalidPhone = "700732236";
            bool isValid = registrationForm.ValidatePhoneNumber(invalidPhone);
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void TestValidatePassword_valid()
        {
            Register registrationForm = new Register();
            string validPass = "daniel2001";
            bool isValid = registrationForm.ValidatePassword(validPass);
            Assert.IsTrue(isValid);
        }
        [TestMethod]
        public void TestValidatePassword_Invalid()
        {
            Register registrationForm = new Register();
            string invalidPass = "dani";
            bool isValid = registrationForm.ValidatePassword(invalidPass);
            Assert.IsFalse(isValid);
        }
    }
}