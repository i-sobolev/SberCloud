<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="main.css" type="text/css"/>
    <link href="fonts/font/SBSansUI-Regular.ttf" rel="stylesheet">
    <link href="fonts/font/SBSansUI-Semibold.ttf" rel="stylesheet">
    <link href="fonts/font/SBSansUI-Bold.ttf" rel="stylesheet">
    <link href="fonts/font/SBSansUI-Light.ttf" rel="stylesheet">
    <title>API Документация</title>
</head>
<body id="API-body">
    <div class="div-block div-main">
        <h1>Описание методов API</h1>
        <p>Ниже приводятся все методы для работы с данными</p>

        <!-- Auth -->
        <div class="div-flex params-name">
            <h2>GET /Auth</h2>
            <p id="description">Возвращает токен пользователя</p>
        </div>
        <p class="big"><b>Передаваемые параметры:</b></p>
        <div class="div-block">
            <div class="div-flex">
                <p>login</p>
                <div class="div-block div-right">
                    <p>Логин пользователя или почта</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>password</p>
                <div class="div-block div-right">
                    <p>Пароль</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>
        <p class="big"><b>Возвращает:</b></p>
        <div class="div-block">
            <pre class="my-pre">

            {
                "id": 0,
                "firstName": "string",
                "middleName": "string",
                "lastName": "string",
                "roleId": 0,
                "countryId": 0,
                "ipAddress": "string",
                "regionId": 0,
                "login": "string",
                "password": "string",
                "lawFirmId": 0,
                "email": "string",
                "phone": "string"
            }
            </pre>
        </div>

        <!-- post Chat -->
        <div class="div-flex params-name">
            <h2>POST /Chat</h2>
            <p id="description">Создает новый чат в базе данных</p>
        </div>
        <p class="big"><b>Передаваемые параметры:</b></p>
        <div class="div-block">
            <div class="div-flex">
                <p>id</p>
                <div class="div-block div-right">
                    <p>Индификатор чата</p>
                    <p class="light">целое число, автоинкремент</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>name</p>
                <div class="div-block div-right">
                    <p>Название чата</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>dateCreated</p>
                <div class="div-block div-right">
                    <p>Unix дата создания чата</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>typeId</p>
                <div class="div-block div-right">
                    <p>Индификатор типа чата</p>
                    <p class="light">целое число</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>adminId</p>
                <div class="div-block div-right">
                    <p>Индификатор создателя чата</p>
                    <p class="light">целое число</p>
                </div>
            </div>
        </div>
        <p class="big"><b>Пример:</b></p>
        <div class="div-block">
            <pre class="my-pre">

            {
                "id": 0,
                "name": "string",
                "dateCreated": "string",
                "typeId": 0,
                "adminId": 0
            }
            </pre>
        </div>

        <!-- get Chat -->
        <div class="div-flex params-name">
            <h2>GET /Chat</h2>
            <p id="description">Возвращает данные о запрошенном чате</p>
        </div>
        <p class="big"><b>Передаваемые параметры:</b></p>
        <div class="div-block">
            <div class="div-flex">
                <p>userId</p>
                <div class="div-block div-right">
                    <p>Индификатор</p>
                    <p class="light">целое число</p>
                </div>
            </div>
        </div>

        <p class="big"><b>Возвращает:</b></p>
        <div class="div-block">
            <pre class="my-pre">

            {
                "id": 0,
                "user": {
                    "id": 0,
                    "firstName": "string",
                    "middleName": "string",
                    "lastName": "string",
                    "roleId": 0,
                    "countryId": 0,
                    "ipAddress": "string",
                    "regionId": 0,
                    "login": "string",
                    "password": "string",
                    "lawFirmId": 0,
                    "email": "string",
                    "phone": "string"
                },
                "chat": {
                    "id": 0,
                    "name": "string",
                    "dateCreated": "string",
                    "typeId": 0,
                    "adminId": 0
                }
            }
            </pre>
        </div>

        <!-- Country -->
        <div class="div-flex params-name">
            <h2>GET /Country</h2>
            <p id="description">Возвращает массив данных о всех странах</p>
        </div>
        <p class="big"><b>Возвращает:</b></p>
        <div class="div-block">
            <pre class="my-pre">

            [
                {
                    "id": 0,
                    "name": "string"
                }
            ]
            </pre>
        </div>

        <!-- get Message -->
        <div class="div-flex params-name">
            <h2>GET /Chat</h2>
            <p id="description">Возвращает данные о запрошенном чате</p>
        </div>
        <p class="big"><b>Передаваемые параметры:</b></p>
        <div class="div-block">
            <div class="div-flex">
                <p>userId</p>
                <div class="div-block div-right">
                    <p>Индификатор</p>
                    <p class="light">целое число</p>
                </div>
            </div>
        </div>

        <p class="big"><b>Возвращает:</b></p>
        <div class="div-block">
            <pre class="my-pre">

            {
                "id": 0,
                "user": {
                    "id": 0,
                    "firstName": "string",
                    "middleName": "string",
                    "lastName": "string",
                    "roleId": 0,
                    "countryId": 0,
                    "ipAddress": "string",
                    "regionId": 0,
                    "login": "string",
                    "password": "string",
                    "lawFirmId": 0,
                    "email": "string",
                    "phone": "string"
                },
                "chat": {
                    "id": 0,
                    "name": "string",
                    "dateCreated": "string",
                    "typeId": 0,
                    "adminId": 0
                }
            }
            </pre>
        </div>

        <!-- Region -->
        <div class="div-flex params-name">
            <h2>GET /Region</h2>
            <p id="description">Возвращает массив данных о всех регионах</p>
        </div>
        <p class="big"><b>Возвращает:</b></p>
        <div class="div-block">
            <pre class="my-pre">

            [
                {
                    "id": 0,
                    "name": "string"
                }
            ]
            </pre>
        </div>

        <!-- post User -->
        <div class="div-flex params-name">
            <h2>POST /User</h2>
            <p id="description">регистрирует нового пользователя</p>
        </div>
        <p class="big"><b>Параметры:</b></p>
        <div class="div-block">
            <div class="div-flex">
                <p>id</p>
                <div class="div-block div-right">
                    <p>Индификатор пользователя</p>
                    <p class="light">целое число, автоинкремент</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>firstName</p>
                <div class="div-block div-right">
                    <p>Имя пользователя</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>middleName</p>
                <div class="div-block div-right">
                    <p>Фамилия пользователя</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>lastName</p>
                <div class="div-block div-right">
                    <p>Отчество пользователя</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>roleId</p>
                <div class="div-block div-right">
                    <p>Индификатор роли пользователя</p>
                    <p class="light">целое число</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>countryId</p>
                <div class="div-block div-right">
                    <p>Индификатор страны пользователя</p>
                    <p class="light">целое число</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>ipAddress</p>
                <div class="div-block div-right">
                    <p>Ip адрес пользователя</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>regionId</p>
                <div class="div-block div-right">
                    <p>Индификатор географического региона пользователя</p>
                    <p class="light">целое число</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>login</p>
                <div class="div-block div-right">
                    <p>Логин пользователя</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>password</p>
                <div class="div-block div-right">
                    <p>Пароль пользователя</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>lawFirmId</p>
                <div class="div-block div-right">
                    <p>Индификатор фирмы пользователя</p>
                    <p class="light">целое число</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>email</p>
                <div class="div-block div-right">
                    <p>Почта пользователя</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>

        <div class="div-block">
            <div class="div-flex">
                <p>phone</p>
                <div class="div-block div-right">
                    <p>Телефон пользователя</p>
                    <p class="light">строка</p>
                </div>
            </div>
        </div>
        <p class="big"><b>Пример:</b></p>
        <div class="div-block">
            <pre class="my-pre">

            {
                "id": 0,
                "firstName": "string",
                "middleName": "string",
                "lastName": "string",
                "roleId": 0,
                "countryId": 0,
                "ipAddress": "string",
                "regionId": 0,
                "login": "string",
                "password": "string",
                "lawFirmId": 0,
                "email": "string",
                "phone": "string"
            }
            </pre>
        </div>    

        <!-- get User -->
        <div class="div-flex params-name">
            <h2>GET /User</h2>
            <p id="description">Возвращает данные о всех пользователях</p>
        </div>
        <p class="big"><b>Возвращает:</b></p>
        <div class="div-block">
            <pre class="my-pre">

            [
                {
                    "id": 0,
                    "firstName": "string",
                    "middleName": "string",
                    "lastName": "string",
                    "roleId": 0,
                    "countryId": 0,
                    "ipAddress": "string",
                    "regionId": 0,
                    "login": "string",
                    "password": "string",
                    "lawFirmId": 0,
                    "email": "string",
                    "phone": "string"
                }
            ]
            </pre>
        </div> 
    </div>
</body>
</html>