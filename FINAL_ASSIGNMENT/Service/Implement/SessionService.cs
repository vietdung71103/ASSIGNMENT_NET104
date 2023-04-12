using FINAL_ASSIGNMENT.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FINAL_ASSIGNMENT.Service.Implement
{
    public static class SessionService
    {
        //Lấy ra danh sách các sản phẩm từ session
        public static List<Product> GetObjectFromSession(ISession session, string key)
        {
            string jsonData = session.GetString(key);// Lấy data dạng string từ Session
            if (jsonData == null)//Chưa có gì trong session
            {
                return new List<Product>();//Trả về 1 danh sách sản phẩm trống
            }
            else
            {
                var pr = JsonConvert.DeserializeObject<List<Product>>(jsonData);//Nếu  dữ liệu có thì ta chuyển đổi dữ liệu thu được về dạng List<Obj>
                return pr;
            }
        }
        //public static List< User> GetUserFromSession(ISession session, string key)
        //{
        //    string jsonData = session.GetString(key);
        //    if (jsonData == null)
        //    {
        //        return new List< User>();
        //    }
        //    else
        //    {
        //        var user = JsonConvert.DeserializeObject< List<User> >(jsonData);
        //        return user;
        //    }
        //}
        public static User GetUserFromSession(ISession session, string key)
        {
            string jsonData = session.GetString(key);
            if (jsonData == null)
            {
                return null;
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(jsonData);
                return user;
            }
        }
        //Ghi lại danh sách sản phẩm vào session
        public static void SetObjectToSession(ISession session, string key, object value)
        {
            //Chuyển đổi dữ liệu ban đầu về dạng chuỗi json để ghi vào session
            var jsonData = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonData);
        }
        //Kiểm tra xem sản phẩm có nằm trong 1 list hay không
        public static bool CheckObjectInList(Guid ID, List<Product> pr)
        {
            return pr.Any(c => c.Id == ID);
            //Trả về true nếu điều kiện thoả mãn và list không rỗng, false nếu ngược lại
        }
    }
}
