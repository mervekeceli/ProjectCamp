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
