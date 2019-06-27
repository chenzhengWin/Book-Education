using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TuShuJieYueYi_Web.Admin.Hander
{
    /// <summary>
    /// imgUploadHandler 的摘要说明
    /// </summary>
    public class imgUploadHandler : IHttpHandler
    {


        private HttpContext _httpContext;
        Images img = new Images();//创建image对象实例，用于获取图片路径以及判断图片是否成功
        public void ProcessRequest(HttpContext context)
        {
            _httpContext = context;
            //获取请求  
            string requestAction = context.Request.Form["action"];
            switch (requestAction)
            {
                //上传图片  
                case "UploadImage":
                    TemporaryMeidaUpload();
                    break;
            }
        }

        /// <summary>  
        /// 上传临时素材  
        /// </summary>  
        private void TemporaryMeidaUpload()
        {
            //返回格式：{"status":"error,success,warning","msg":""}  

            // string result = "{\"status\":\"{0}\",\"msg\":\"{1}\"}";   
            try
            {
                //根据前台html的name获取文件  
                HttpPostedFile upfile = _httpContext.Request.Files["file_Image"];

                if (upfile == null)
                {
                    img.Success = false;
                    img.ImgUrl = "";
                    img.ImgMsg = "没有选择文件";
                    _httpContext.Response.Write(new JavaScriptSerializer().Serialize(img));


                }

                //文件原名称  获取原始图片的名称
                string oldMediaName = upfile.FileName;

                //文件后辍名称  
                string oldMediaExtension = Path.GetExtension(oldMediaName);

                //判断文件格式是否符合要求  
                if (oldMediaExtension.ToLower() == (".jpg") || oldMediaExtension.ToLower() == (".gif") || oldMediaExtension.ToLower() == (".jpeg") || oldMediaExtension.ToLower() == (".png"))
                {

                    //判断文件大小是否符合要求  
                    if (upfile.ContentLength >= (1024 * 1024 * 1))
                    {

                        img.Success = false;
                        img.ImgUrl = "";
                        img.ImgMsg = "请上传1M以内的文件！";
                        _httpContext.Response.Write(new JavaScriptSerializer().Serialize(img));
                        return;
                    }
                    //用年月日时分秒生成新的图片的名称
                    string imgName = DateTime.Now.ToString("yyyy-MM-dd-HH-ss") + DateTime.Now.Ticks;
                    bool flag = false;
                    string savePath = _httpContext.Server.MapPath("~/Upload");
                    try
                    {
                        if (!string.IsNullOrEmpty(oldMediaName))
                        {
                            if (!System.IO.Directory.Exists(savePath))
                            {
                                System.IO.Directory.CreateDirectory(savePath);
                            }
                            upfile.SaveAs(_httpContext.Server.MapPath("/Upload/" + imgName + oldMediaExtension));
                            flag = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //写入日志   
                    }
                    if (flag)
                    {
                        //返回json   
                        var url = "/Upload/" + imgName + oldMediaExtension;
                        img.Success = true; 
                        img.ImgUrl = url;
                        _httpContext.Response.Write(new JavaScriptSerializer().Serialize(img));
                    }
                    else
                    {
                        img.Success = false;
                        img.ImgUrl = "";
                        File.Delete(_httpContext.Server.MapPath("/Upload/" + imgName + ".jpg"));
                        _httpContext.Response.Write(new JavaScriptSerializer().Serialize(img));

                    }
                }
                else
                {
                    img.Success = false;
                    img.ImgUrl = "";
                    img.ImgMsg = "请上传图片格式的文件！";
                    _httpContext.Response.Write(new JavaScriptSerializer().Serialize(img));
                    return;
                }
            }
            catch (Exception EX_NAME)
            {
                img.Success = false;
                img.ImgUrl = "";
                img.ImgMsg = EX_NAME.ToString();
                _httpContext.Response.Write(new JavaScriptSerializer().Serialize(img));
                // ResponseWriteEnd(status.error.ToString(), EX_NAME.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}