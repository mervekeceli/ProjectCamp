1.Proje ASP.Net 6 kullanýlarak oluþturuldu <br />
2.Katmanlar oluþturuldu ve Entity classlarý eklendi <br />
3.DBContext ayarlarý ile db konfigürasyonlarý yapýldý <br />
4.Migration ile db oluþturuldu <br />
 -add-migration MigName <br />
 -update-database <br /><br />

NOT: Writer tablosunda sonradan güncelleme yaptýktan sonra þu þekidle migration yaptýrdý:<br />
- EntityFrameworkcore\add-migration MigName <br />
- EntityFrameworkcore\update-databse <br />

-> Partial Kullanýmý için: @await Html.PartialAsync("AboutPartial") <br />
