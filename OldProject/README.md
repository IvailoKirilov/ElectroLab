Вижте го на https://electrolaboratory.eu/

# 4.1. Цели
ЕлектроЛаб е иновативно уеб приложение, създадено с цел да предостави на потребителите удобна и функционална платформа за създаване, публикуване и споделяне на уроци, свързани с Arduino, IoT технологии и електроника в най-широкия смисъл. Основната цел на приложението е да осигури достъп до висококачествени учебни материали и ресурси, които могат да бъдат използвани както от начинаещи, така и от напреднали в тези области.
Чрез платформата, потребителите ще имат възможността не само да създават собствени уроци, но и да ги публикуват и споделят с други, като така обогатяват общността с ценни знания и практически примери. Всеки урок може да бъде съпътстван с тест, който позволява на потребителите да затвърдят и проверят своите знания по съответната тема. Това прави платформата полезна не само за самообучение, но и за съвместно учене и обмен на опит между различни потребители.
ЕлектроЛаб е предназначено да бъде място за активно взаимодействие и обучение, което да помогне на хората да развият своите умения в сферата на електрониката и съвременните технологиите, като Arduino и IoT.
# 4.2. Основни етапи в реализирането на проекта
Първоначално започнахме с анализ на различни подобни сайтове, за да разгледаме техните основни характеристики, какво ги отличава едни от други и какви възможности за подобрение съществуват при тях. Това ни даде ясна представа за съществуващите тенденции в областта и за функциите, които биха били полезни и за нашия проект. Въз основа на събраната информация, решихме коя технология ще използваме за разработката на проекта.
След като избрахме най-подходящата технология, която отговаряше на нуждите на проекта и на нашите умения, преминахме към фазата на планиране. Подготвихме детайлни схеми за всички необходими модули, таблици с данни, страници и функционалности, които трябваше да бъдат включени в сайта. Този етап беше изключително важен, за да имаме ясна структура и цел при разработката на проекта.
С помощта на разработения план започнахме реалната програма на кода. През целия процес периодично преглеждахме написания код и го редактирахме, за да гарантираме, че той отговаря на зададените стандарти и изисквания. Преглеждахме го също така, за да подобрим функционалността и производителността на сайта.
След като завършихме основната част от разработката, публикувахме проекта и започнахме да се грижим за поддръжката му. Поддръжката включва редовно обновяване на сайта, решаване на възникнали проблеми и внедряване на нови функционалности.
# 4.3. Ниво на сложност на проекта:
При разработката на уеб приложението се сблъскахме с различни трудности. Един от основните проблеми беше създаването на логиката за тестовете, което изискваше внимателно планиране, за да обхванем всички функционалности. Изборът на подходяща архитектура също беше предизвикателство, тъй като трябваше да вземем предвид мащабируемостта, производителността и поддръжката на приложението. Реализацията на модулите също не беше лесна, тъй като трябваше да осигурим тяхната интеграция и безпроблемна работа. Освен това, планирането на функциите в рамките на ограниченото време доведе до редовни преоценки и адаптиране на приоритетите.
# 4.4. Логическо и функционално описание на решението:
„ЕлектроЛаб“ е уеб приложение, разработено с помощта на технологията ASP.NET и използва архитектурния модел ASP.NET MVC (Model-View-Controller). Този модел предлага ясно разделение на логическите слоеве на приложението – модел, изглед и контролер. Използваме MSSQL за база данни и осъществяваме комуникация с нея чрез Entity Framework, което представлява ORM (Object-Relational Mapping) към ASP.NET. За управление на потребителските профили, роли и свързаност с базата данни използваме Identity Framework, библиотека, интегрирана в ASP.NET MVC. Във фронт-енд частта на приложението използваме Bootstrap поради лесната му употреба и бързото свързване с ASP.NET. Bootstrap предоставя готови стилове и компоненти, които ни позволяват бързо да създадем адаптивен и отзивчив дизайн, като същевременно осигуряваме добра съвместимост с ASP.NET, което ускорява процеса на разработка и подобрява потребителското изживяване.
![The-Spring-MVC-architecture-as-depicted-in-16](https://github.com/user-attachments/assets/459b67fc-7cec-4875-80ae-ca009c372b5f)
Чрез MVC архитектурата, приложението е разделено на три основни слоя: контролерите съдържат бизнес логиката на проекта, моделите се грижат за данните и връзката с базата данни, а изгледите дефинират визуалното представяне на информацията, която вижда потребителят.
# 4.5. Реализация:
Приложението се разработва от двама ни с помощта на Visual Studio 2022 Community, което осигурява удобна среда за работа с ASP.NET и свързаните технологии. За управление на базата данни използваме Microsoft SQL Server Management Studio, което ни предоставя лесен достъп до базата и нейните данни. За следене на напредъка и организиране на задачите си ползваме платформата Trello, чрез която структурирахме всички стъпки и функционалности, които трябва да бъдат изпълнени, като така осигуряваме ефективна комуникация и управление на проекта.
# 4.6. Описание на приложението
За да използвате приложението, трябва да имате Visual Studio 2022 с Web Development with .NET пакет. След като го изтеглите, отваряте проекта през .sln файла. Като го изтеглите, цъкате зеления бутон, на който пише “https” след малко време сайта се отваря. 
Потребителски логин:
User: “User123”
Pass: “User123!”
Администраторски логин:
User: “Admin123”
Pass: “Admin123!”
Собственик логин:
User: “Owner123”
Pass: “Owner123!”
# 4.7. Заключение
„ЕлектроЛаб“ постигна целта си да създаде платформа за създаване, споделяне и изучаване на уроци по Arduino, IoT и електроника. Използвайки ASP.NET MVC, Entity Framework и Bootstrap, разработихме функционално и удобно уеб приложение с модерен дизайн. Преодоляхме ключови предизвикателства като логиката на тестовете и управлението на потребители, създавайки стабилна и разширяема система. Платформата е готова за бъдещи подобрения и развитие на общността.
