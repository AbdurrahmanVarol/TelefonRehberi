# TelefonRehberi.API

## Projenin işlevler: <br/>
	• Rehberde kişi oluşturma
	• Rehberde kişi kaldırma 
	• Rehberde kişi güncelleme
	• Rehberde kişi silme 
	• Rehberdeki kişilerin listelenmesi 
	• Rehberdeki kişiye iletişim bilgisi ekleme 
	• Rehberdeki kişiden iletişim bilgisi kaldırma 
	• Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi 
	• Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor talebi
## Teknik Tasarım <br/>
	### Kişiler: 
		• UUID 
		• Ad 
		• Soyad 
		• Firma
	### İletişim Bilgisi 
		• Bilgi Tipi: Telefon Numarası, E-mail Adresi, Konum 
		• Bilgi İçeriği 
	### Rapor: 
 		Basitçe aşağıdaki bilgileri içerecektir:
		• Konum Bilgisi 
			o En çok -> En az olacak şekilde konumlarının sayılarıyla listelenmesi 
			o O konumda yer alan rehbere kayıtlı kişi sayısı 
			o O konumda yer alan rehbere kayıtlı telefon numarası sayısı

## Kullanım 
	
Veri tabanı ve redis conneciton stingleri TelefonRehbei.API projesinin içerisindeki application.json içerisinde tutulmaktadır.

### Controller 
	#### PersonsController:
		HttpGet:
		• /Persons: Rehbere kayıtlı tüm kişileri getitir
		• /Person/{personId} : İd li kişiyi getirir.
		• /Person/report : Kişilerin konum bilgilerine göre bir istatistik raporu dönderir.

		HttpPost: 
		•/Persons: Body kısmından bir kişimodel tütünde nesne alır. 
			   Bu nesneyi veri tabanına ekler ve 200 Ok döner. 
			   Nesne Null gönderilmişse BadRequest döner. 
		HttpPut: 
		•/Persons : Body kısmından bir kişimodel tütünde nesne alır. 
			    Bu nesneyi güncelleyip veri tabanına ekler ve 200 Ok döner. 
			    Nesne Null gönderilmişse BadRequest döner. 
		HttpDelete: 
		•/Persons/{personId} : Parametre olarak alınana ıd li kayıt bulunmazsa NotFound döner. 
				       Id li kayıt bulunursa kayıtı veri tabanından silip NoContent döner. 

	#### InfosController: 
		HttpGet: 
		• /Infos: Rehbere kayıtlı tüm iletişim bilgilerini getitir. 
		• /Infos: {infoId}: İd li iletişim bilgisini getirir. 
		HttpPost: 
		•/Infos:   Body kısmından bir infomodel tütünde nesne alır. 
			   Bu nesneyi veri tabanına ekler ve 200 Ok döner. 
			   Nesne Null gönderilmişse BadRequest döner. 
			   Bu nesne içerisinde personId gönderilmediyse BadRequest döner. 
		HttpPut: 
		•/Infos:   Body kısmından bir infomodel tütünde nesne alır. 
			   Bu nesneyi veri tabanındaki kaydı günceller ve 200 Ok döner. 
			   Nesne Null gönderilmişse BadRequest döner. 
			   Bu nesne içerisinde personId gönderilmediyse BadRequest döner. 
		HttpDelete: 
		•/Infos/{infoId} : Parametre olarak alınana ıd li kayıt bulunmazsa NotFound döner. 
				       Id li kayıt bulunursa kayıtı veri tabanından silip NoContent döner. 
## Kullanılan Kütüphaneler: <br/>
	• EntityFrameworkCore 
	• EntityFrameworkCore.Desşgn 
	• EntityFrameworkCore.InMemory 
	• EntityFrameworkCore.Relational 
	• EntityFrameworkCore.SqlServer 
	• EntityFrameworkCore.Tools 
	• Moq 
	• Newtonsoft.Json 
	• NUnit 
	• StackExchange.Redis 

	
	
