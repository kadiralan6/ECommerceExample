using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Utilities
{
    public class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz Bulunmamaktadır.";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static class Product
        {
            public static string ProductAdded = "Ürün Başarıyla Eklenmiştir";
            public static string NotFound = "Listelenecek Ürün Bulunamamıştır.";
            public static string ProductDeleted(string productCode)
            {
                return $"{productCode} kodlu ürün başarıyla Silinmiştir.";
            } 
            public static string ProductUpdated(string productCode)
            {
                return $"{productCode} kodlu ürün başarıyla güncellemiştir.";
            }
        }

        public static class Category
        {
            public static string CategoryAdd = "Kategori Başarıyla Eklenmiştir";
            public static string CategoryDeleted = "Kategori Başarıyla Silinmiştr";
            public static string CategoryUpdate = "Kategori Başarıyla Güncellenmiştir.";
            public static string NotFound = "Listelenecek Kategori Bulunamamıştır.";

        }
    
    }
}
