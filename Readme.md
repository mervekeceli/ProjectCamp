1.Proje ASP.Net 6 kullan�larak olu�turuldu <br />
2.Katmanlar olu�turuldu ve Entity classlar� eklendi <br />
3.DBContext ayarlar� ile db konfig�rasyonlar� yap�ld� <br />
4.Migration ile db olu�turuldu <br />
 -add-migration MigName <br />
 -update-database <br /><br />

NOT: Writer tablosunda sonradan g�ncelleme yapt�ktan sonra �u �ekidle migration yapt�rd�:<br />
- EntityFrameworkcore\add-migration MigName <br />
- EntityFrameworkcore\update-databse <br />

-> Partial Kullan�m� i�in: @await Html.PartialAsync("AboutPartial") <br />

<hr />
<br /> <br />

-> <h5>Oturum Y�netimi</h5> <br />
<hr />

Bu yakla��mda: <br />

- Session kullanm�yorsunuz, bunun yerine Claims ile kimlik do�rulama yap�l�yor. <br />
- Authorization attribute'u ([Authorize]) ile rol kontrol� yaparak g�venli bir �ekilde kullan�c�n�n yetkilerini kontrol ediyorsunuz. <br />
- ��k�� i�lemi i�in SignOutAsync kullanarak g�venli bir �ekilde kullan�c�y� oturumdan ��kar�yorsunuz. <br />
- Bu y�ntemle uygulaman�z daha g�venli ve y�netimi kolay hale gelir. <br  />

<hr />
Session Kullan�m�yla Kar��la�t�rma<br>
Session: Oturumda saklanan veriler sunucu taraf�nda tutulur. Kullan�c� sayfalar aras�nda gezinirken oturum bilgileri kaybolmaz.<br>
Claims: Kullan�c� bilgileri genellikle kimlik do�rulama s�ras�nda saklan�r ve JWT Token veya ASP.NET Core Identity gibi sistemlerle birlikte kullan�l�r. Bu bilgiler istemci taraf�nda (browser) ta��n�r (cookie veya token �eklinde).<br>
