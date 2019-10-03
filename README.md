# ASP.NET-MVC-Template
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2FHiroHsu%2FASP.NET-MVC-Template.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2FHiroHsu%2FASP.NET-MVC-Template?ref=badge_shield)

#### 以.Net Framework 4.6.2 為基礎做的 MVC5 網站樣板，用來加快專案的產生，減少一些專案前期的工作

## 簡介
### 起心動念
我在開啟新的網路應用程式專案的時候，常常需要做一些前置的動作，比如像是從Nuget安裝某些套件，然後把一些常用的方法從另外一個專案複製過來，常常需要一段時間來做這些瑣事，這些時間大約會用掉我兩到三天的時間，當我的年紀越來越大的時候，我發現我的時間越來越不夠用了，我沒有辦法再接受這樣的時間浪費，因此我在這一年中利用業餘的時間進行了一些整合，逐漸的完善所心中那個加快我工作的樣板。

最近(2019年開始)的.NET 生態圈逐漸從 .Net Framework 轉向 .Net Core ，我發現我這一年中做的事情有點落伍了，但因為不是所有的開發者都往 .Net Core 靠攏，我預計先做.Net Framework 為主體的樣板，後面再做 .Net Core 的樣板。

### 授權
這個樣板將會是全新的，因為之前我所整合的樣版有許多GPL授權的程式碼，而我這個專案樣板希望能協助未來的每個好朋友，又希望可以得到各位好朋友的回饋，因此我選擇了 MPL 2.0 授權條款，並且重新編寫程式碼，但是其中許多觀念都是來自於這些GPL開放原始碼的專案，我特別的感謝。

***

## 使用方式
### 直接下載使用
你可以直接下載這個專案，用在任何地方，但這種方式最大的缺點就是專案名稱的改變，將會變得很困難。
如果你想快速的改變專案名稱，我建議使用下一個方式

### 下載後建立專案範本
當你下載這個專案後，在專案選單中選擇匯出範本，接著按照上面所需要內容填寫，你將會得到一個專案範本，這時候你就可以在建立專案的時候使用這個範本，在此同時，你可以自由的輸入專案名稱。
詳細的專案範本產生方式，可以參考微軟的說明。

### 直接使用專案範本
在這個專案完成部分目標之前，我還不會將他做成專案範本。
如果未來有做成專案範本，我在下面放上連結。

---

## 預計目標

我已經在我整合的專案中採用以下內容，但是我在這裡將會重新寫過相關的程式碼，因此我預計完成的目標將會如下

- [ ] 特性
  - [x] 依賴注入
  - [ ] 快取機制切換
    - [ ] 記憶體快取機制
    - [ ] Redis 快取機制
  - [ ] 多語言
  - [x] 非物理刪除
  - [ ] 異常紀錄
  - [ ] 稽核
  - [x] 多資料庫
  
- [ ] 後端
  - [ ] SinglR
  - [ ] HangFire
  - [ ] EntityFramework
  - [ ] Swagger
  
- [ ] 前端
  - [x] Vue.Js
  - [x] Axios
  
- [ ] 模式
  - [ ] 工作單元模式
  - [x] 倉儲模式
  - [x] 單例模式     
  


## 知識範圍
想要使用這個專案，你必須懂得一些開發的技術與技巧，以下是我認為可能或者必須了解的知識範圍，如果你對於某些知識還不是那麼清楚，可以先理解這些內容，再回頭來使用這個專案。

1. 開發理論類
    1. OOP
    1. SOLID  
    1. DI/IOC
2. 軟體工程類
    1. TDD(Test-Driven Development)
    1. DDD(Domain-Driven Design)
    1. Repository Pattern
    1. UnitOfWork
    1. Factory Method Pattern
    1. Strategy Pattern
    1. Singleton Pattern
3. 後端開發框架類
    1. ASP.NET MVC
    1. WebAPI2
    1. Identity
    1. Oauth
    1. EntityFrameork Code First
    1. SignalR
    1. Owin
4. 前端開發框架類
    1. Jquery
    1. Vue.js
    1. Element-UI
    1. Axios
    1. JavaScript ES6
5. 套件應用
    1. AutoFac
    1. AutoMapper
    1. Dapper
    1. Elmah
    1. Swagger
    1. HangFire
    1. Nlog
    1. NUnit
    1. Redis
    1. EPPlus
6. C# 語言特性
    1. LINQ
    1. Reflection
    1. Asynchronous
    1. Regular Expression





## License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2FHiroHsu%2FASP.NET-MVC-Template.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2FHiroHsu%2FASP.NET-MVC-Template?ref=badge_large)