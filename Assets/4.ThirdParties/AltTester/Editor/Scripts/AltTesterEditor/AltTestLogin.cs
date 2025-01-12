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

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }
}



//// For more info on the setup, check out our docs https://alttester.com/docs/sdk/latest/pages/get-started.html#write-and-execute-first-test-for-your-app
//using AltTester.AltTesterUnitySDK.Driver;
//using NUnit.Framework;

//public class MyTests
//{
//    private AltDriver altDriver;

//    [OneTimeSetUp]
//    public void OneTimeSetUp()
//    {
//        // Khởi tạo AltDriver
//        altDriver = new AltDriver(host: "127.0.0.1", port: 13000, appName: "__default__");
//    }

//    [OneTimeTearDown]
//    public void TearDown()
//    {
//        // Dừng AltDriver
//        altDriver.Stop();
//    }

//    [Test]
//    public void TestLoginAndWelcomeText()
//    {
//        // Chờ và nhấn nút Login
//        var btnLogin = altDriver.WaitForObject(By.PATH, "/Canvas/Container/Body/Content/Login/BtnLogin");
//        btnLogin.Click();

//        // Chờ và nhập email vào trường Email
//        var ipfEmail = altDriver.WaitForObject(By.PATH, "/Canvas/Container/Body/Content/Detail/Email/IpfEmail");
//        ipfEmail.Click();
//        ipfEmail.SetText("taggletester");

//        // Chờ và nhập mật khẩu vào trường Password
//        var ipfPassword = altDriver.WaitForObject(By.PATH, "/Canvas/Container/Body/Content/Detail/Password/IpfPassword");
//        ipfPassword.Click();
//        ipfPassword.SetText("Aa123123!@#");

//        // Nhấn nút Login
//        var btnLogin1 = altDriver.WaitForObject(By.PATH, "/Canvas/Container/Body/Content/Detail/Login/BtnLogin");
//        btnLogin1.Click();

//        // Tải màn hình chính (HomePage)
//        altDriver.LoadScene("Taggle.HomePage", true);

//        // Kiểm tra xem text Welcome có tồn tại hay không
//        var txtWelcome = altDriver.WaitForObject(By.PATH, "/Canvas/Container/TopBar/TxtWelcome");
//        Assert.IsNotNull(txtWelcome, "Text Welcome không tồn tại!");
//    }
//}
