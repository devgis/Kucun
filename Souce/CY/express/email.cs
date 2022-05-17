using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dm.Model.V20151123;

namespace CY.DA
{
    public class email
    {
        public void SMail()
        {
            IClientProfile profile = DefaultProfile.GetProfile("mail.cn2sg.com", "LTAIClE4lJi5ulWc", "KYZZEGyIGqNVxHN6HaDTiAb7FtZNMO");
            IAcsClient client = new DefaultAcsClient(profile);
            SingleSendMailRequest request = new SingleSendMailRequest();
            try
            {
                request.AccountName = "info@mail.cn2sg.com";
                request.FromAlias = "发信人昵称";
                request.AddressType = 1;
                request.TagName = "控制台创建的标签";
                request.ReplyToAddress = true;
                request.ToAddress = "157075023@qq.com";
                request.Subject = "邮件主题";
                request.HtmlBody = "邮件正文";
                SingleSendMailResponse httpResponse = client.GetAcsResponse<SingleSendMailResponse>(request);
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
            //catch (ServerException e)
            //{
            //    e.printStackTrace();
            //}
            //catch (ClientException e)
            //{
            //    e.printStackTrace();
            //}
        }
    }
}