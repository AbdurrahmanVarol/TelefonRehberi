# TelefonRehberi.API

## Projenin işlevler: <br/>
	• Rehberde kişi oluşturma <br/>
	• Rehberde kişi kaldırma <br/>
	• Rehberde kişi güncelleme <br/>
	• Rehberde kişi silme <br/>
	• Rehberdeki kişilerin listelenmesi <br/>
	• Rehberdeki kişiye iletişim bilgisi ekleme <br/>
	• Rehberdeki kişiden iletişim bilgisi kaldırma <br/>
	• Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi <br/>
	• Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor talebi <br/>
## Teknik Tasarım <br/>
	### Kişiler: <br/>
		• UUID <br/>
		• Ad <br/>
		• Soyad <br/>
		• Firma<br/>
	### İletişim Bilgisi <br/>
		• Bilgi Tipi: Telefon Numarası, E-mail Adresi, Konum <br/>
		• Bilgi İçeriği <br/>
	### Rapor: <br/>
 		Basitçe aşağıdaki bilgileri içerecektir: <br/>
		• Konum Bilgisi <br/>
			o En çok -> En az olacak şekilde konumlarının sayılarıyla listelenmesi <br/>
			o O konumda yer alan rehbere kayıtlı kişi sayısı <br/>
			o O konumda yer alan rehbere kayıtlı telefon numarası sayısı<br/>

## Kullanım <br/>
	
Veri tabanı ve redis conneciton stingleri TelefonRehbei.API projesinin içerisindeki application.json içerisinde tutulmaktadır.<br/>

### Controller <br/>
	#### PersonsController:<br/>
		HttpGet:<br/>
		• /Persons: Rehbere kayıtlı tüm kişileri getitir.<br/>
		• /Person/{personId} : İd li kişiyi getirir.<br/>
		• /Person/report : Kişilerin konum bilgilerine göre bir istatistik raporu dönderir.<br/>

		HttpPost: <br/>
		•/Persons: Body kısmından bir kişimodel tütünde nesne alır. <br/>
			   Bu nesneyi veri tabanına ekler ve 200 Ok döner. <br/>
			   Nesne Null gönderilmişse BadRequest döner. <br/>
		HttpPut: <br/>
		•/Persons : Body kısmından bir kişimodel tütünde nesne alır. <br/>
			    Bu nesneyi güncelleyip veri tabanına ekler ve 200 Ok döner. <br/>
			    Nesne Null gönderilmişse BadRequest döner. <br/>
		HttpDelete: <br/>
		•/Persons/{personId} : Parametre olarak alınana ıd li kayıt bulunmazsa NotFound döner. <br/>
				       Id li kayıt bulunursa kayıtı veri tabanından silip NoContent döner. <br/>

	#### InfosController: <br/>
		HttpGet: <br/>
		• /Infos: Rehbere kayıtlı tüm iletişim bilgilerini getitir. <br/>
		• /Infos: {infoId}: İd li iletişim bilgisini getirir. <br/>
		HttpPost: <br/>
		•/Infos:   Body kısmından bir infomodel tütünde nesne alır. <br/>
			   Bu nesneyi veri tabanına ekler ve 200 Ok döner. <br/>
			   Nesne Null gönderilmişse BadRequest döner. <br/>
			   Bu nesne içerisinde personId gönderilmediyse BadRequest döner. <br/>
		HttpPut: <br/>
		•/Infos:   Body kısmından bir infomodel tütünde nesne alır. <br/>
			   Bu nesneyi veri tabanındaki kaydı günceller ve 200 Ok döner. <br/>
			   Nesne Null gönderilmişse BadRequest döner. <br/>
			   Bu nesne içerisinde personId gönderilmediyse BadRequest döner. <br/>
		HttpDelete: <br/>
		•/Infos/{infoId} : Parametre olarak alınana ıd li kayıt bulunmazsa NotFound döner. <br/>
				       Id li kayıt bulunursa kayıtı veri tabanından silip NoContent döner. <br/>
## Kullanılan Kütüphaneler: <br/>
	• EntityFrameworkCore <br/>
	• EntityFrameworkCore.Desşgn <br/>
	• EntityFrameworkCore.InMemory <br/>
	• EntityFrameworkCore.Relational <br/>
	• EntityFrameworkCore.SqlServer <br/>
	• EntityFrameworkCore.Tools <br/>
	• Moq <br/>
	• Newtonsoft.Json <br/>
	• NUnit <br/>
	• StackExchange.Redis <br/>

	
	
