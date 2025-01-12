using NUnit.Framework;
using AltTester.AltTesterUnitySDK.Driver;

public class AltTestLogin
{
    public AltDriver altDriver;

    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver = new AltDriver(port: 13000);
    }

    //Write your tet case for login here
    [Test]
    public void TestValidLogin()
    {
        // Navigate to the login scene
        altDriver.LoadScene("Taggle.Login.UserName");

        // Locate input fields and buttons
        var usernameField = altDriver.WaitForObject(By.NAME, "IpfEmail");
        var passwordField = altDriver.WaitForObject(By.NAME, "IpfPassword");
        var loginButton = altDriver.WaitForObject(By.NAME, "BtnLogin");

        // Input valid credentials
        usernameField.SetText("taggletester");
        passwordField.SetText("Aa123123!@#");

        // Click the login button
        loginButton.Tap();

        //// Verify successful navigation to the homepage
        //var welcomeText = altDriver.WaitForObject(By.NAME, "TxtWelcome", timeout: 5);
        //Assert.IsTrue(welcomeText.GetText().Contains("Welcome taggletester"), "Login failed: User was not redirected to the homepage.");
    }

    [Test]
    public void TestInvalidLogin()
    {
        // Navigate to the login scene
        altDriver.LoadScene("Taggle.Login.UserName");

        // Locate input fields and buttons
        var usernameField = altDriver.WaitForObject(By.NAME, "IpfEmail");
        var passwordField = altDriver.WaitForObject(By.NAME, "IpfPassword");
        var loginButton = altDriver.WaitForObject(By.NAME, "BtnLogin");

        // Input invalid credentials
        usernameField.SetText("wronguser");
        passwordField.SetText("wrongpassword");

        // Click the login button
        loginButton.Tap();

        // Verify error message is displayed
        var errorText = altDriver.WaitForObject(By.NAME, "TxtError", timeout: 5);
        Assert.AreEqual("Username or password is incorrect", errorText.GetText(), "Error message not displayed as expected.");
    }

    [Test]
    public void TestEmptyFieldsLogin()
    {
        // Navigate to the login scene
        altDriver.LoadScene("Taggle.Login.UserName");

        // Locate the login button
        var loginButton = altDriver.WaitForObject(By.NAME, "BtnLogin");

        // Click the login button without entering credentials
        loginButton.Tap();

        // Verify error message is displayed
        var errorText = altDriver.WaitForObject(By.NAME, "TxtError", timeout: 5);
        Assert.AreEqual("Please enter your username and password", errorText.GetText(), "Error message not displayed for empty fields.");
    }


    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }
}

