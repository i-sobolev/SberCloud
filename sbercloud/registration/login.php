<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="reset.css" type="text/css"/>
    <link rel="stylesheet" href="bootstrap.css" type="text/css"/>
    <link rel="stylesheet" href="main.css" type="text/css"/>
    <title>Войти в SberCloud</title>
</head>
<body>
    <div class="div-login">
        <img id="signin-logo" src="sbercloud-logo.png" alt="sbercloud-logo">
        <label id="signin-title">Войти в SberCloud</label>
        <form class="form-block" action="" method="post">
            <label>Логин</label>
            <input class="input-signin" type="text" name="login" placeholder="Username or email address">
            <label>Пароль</label>
            <input class="input-signin" type="password" name="password" placeholder="Password">
            <button type="button" class="btn filled" id="signin-button" name="signin-confirm" onclick="">Войти</button>
        </form>
    </div>
</body>
</html>