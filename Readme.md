1.Proje ASP.Net 6 kullanılarak oluşturuldu <br />
2.Katmanlar oluşturuldu ve Entity classları eklendi <br />
3.DBContext ayarları ile db konfigürasyonları yapıldı <br />
4.Migration ile db oluşturuldu <br />
 -add-migration MigName <br />
 -update-database <br /><br />

NOT: Writer tablosunda sonradan güncelleme yaptıktan sonra şu şekidle migration yaptırdı:<br />
- EntityFrameworkcore\add-migration MigName <br />
- EntityFrameworkcore\update-databse <br />

-> Partial Kullanımı için: @await Html.PartialAsync("AboutPartial") <br />

<hr />
-> <h5>Oturum Yönetimi</h5> <br />
<hr />
Bu yaklaşımda: <br />

- Session kullanmıyorsunuz, bunun yerine Claims ile kimlik doğrulama yapılıyor. <br />
- Authorization attribute'u ([Authorize]) ile rol kontrolü yaparak güvenli bir şekilde kullanıcının yetkilerini kontrol ediyorsunuz. <br />
- Çıkış işlemi için SignOutAsync kullanarak güvenli bir şekilde kullanıcıyı oturumdan çıkarıyorsunuz. <br />
- Bu yöntemle uygulamanız daha güvenli ve yönetimi kolay hale gelir. <br  />

<hr />
Session Kullanımıyla Karşılaştırma<br>
Session: Oturumda saklanan veriler sunucu tarafında tutulur. Kullanıcı sayfalar arasında gezinirken oturum bilgileri kaybolmaz.<br>
Claims: Kullanıcı bilgileri genellikle kimlik doğrulama sırasında saklanır ve JWT Token veya ASP.NET Core Identity gibi sistemlerle birlikte kullanılır. Bu bilgiler istemci tarafında (browser) taşınır (cookie veya token şeklinde).<br>
<hr>
