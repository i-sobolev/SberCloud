<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="reset.css" type="text/css"/>
    <link rel="stylesheet" href="bootstrap.css" type="text/css"/>
    <link rel="stylesheet" href="main.css" type="text/css"/>

    
    <link href="https://fonts.googleapis.com/css?family=Rubik:300,400,700|Oswald:400,700" rel="stylesheet">
    <link rel="stylesheet" type="../text/css" href="../chat/design/my.css">
    <link rel="stylesheet" href="../fonts/icomoon/style.css">

    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/jquery.fancybox.min.css">
    <link rel="stylesheet" href="../css/owl.carousel.min.css">
    <link rel="stylesheet" href="../css/owl.theme.default.min.css">
    <link rel="stylesheet" href="../fonts/flaticon/font/flaticon.css">
    <link rel="stylesheet" href="../css/aos.css">
    
    <link rel="stylesheet" href="../css/style.css">
    <title>Создать аккаунт SberCloud</title>

</head>
<body data-spy="scroll" data-target=".site-navbar-target" data-offset="300">
<div id="overlayer"></div>
  <div class="loader">
    <div class="spinner-border text-primary" role="status">
      <span class="sr-only">Загрузка...</span>
    </div>
  </div>
  
  <div class="site-wrap"  id="home-section">

    <div class="site-mobile-menu site-navbar-target">
      <div class="site-mobile-menu-header">
        <div class="site-mobile-menu-close mt-3">
          <span class="icon-close2 js-menu-toggle"></span>
        </div>
      </div>
      <div class="site-mobile-menu-body"></div>
    </div>
   
      
    <header class="site-navbar js-sticky-header site-navbar-target" role="banner">

      <div class="container">
        <div class="row align-items-center position-relative">
          
            
            <div class="site-logo">
              <img src="../chat/resource/image6.png"/>
            </div>
            
            <?php 
          include ("./menu.php");
        ?>

          <div class="toggle-button d-inline-block d-lg-none"><a href="#" class="site-menu-toggle py-5 js-menu-toggle text-black"><span class="icon-menu h3"></span></a></div>

        </div>
      </div>
      
    </header> 

    <div class="div-login">
        <h1 id="signin-title">Создать аккаунт SberCloud</h1>
        <form class="form-block" action="" method="post" style="margin: 10px 10px 38px 0px;    width: 460px;">
        <fieldset>
                <legend>Информация по аккаунту</legend>
            <label>Логин</label>
              <input class="input-signin" type="text" name="login" placeholder="Введите логин...">
            <label>Почта</label>
              <input class="input-signin" type="text" name="sendEmail" placeholder="Введите Email...">
            <label>Пароль</label>
              <input class="input-signin" type="text" name="password" placeholder="Введите пароль...">
            <label>Подтвердить пароль</label>
              <input class="input-signin" type="password" name="password-conf" placeholder="Повторите пароль...">
              </fieldset>
              <fieldset>
                <legend>Персональная информация</legend>
                  <label>Фамилия</label>
                  <input class="input-signin" type="text" name="surnameUser" >
                  <label>Имя</label>
                  <input class="input-signin" type="text" name="nameUser" >
                  <label>Отчество</label>
                  <input class="input-signin" type="text" name="lastNameUser" >
                  <label>Страна</label>
                  <input class="input-signin" type="text" name="countryUser" value="Россия" disabled>
                  <label>Регион</label>
                  <input class="input-signin" type="text" name="regionUser" value="Москва" disabled>
                  <label>Телефон</label>
                  <input class="input-signin" type="text" name="phoneUser">
              </fieldset>

            <button type="submit" style="width:212px;" class="brn" id="signin-button" name="signin-confirm" onclick="">Создать аккаунт</button>
        </form>
 </div>

    <footer class="site-footer">
      <div class="container">
        <div class="row">
       
          
        </div>
      </div>
    </footer>

  </div>

  <script src="js/jquery-3.3.1.min.js"></script>
  <script src="js/popper.min.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/owl.carousel.min.js"></script>
  <script src="js/jquery.sticky.js"></script>
  <script src="js/jquery.waypoints.min.js"></script>
  <script src="js/jquery.animateNumber.min.js"></script>
  <script src="js/jquery.fancybox.min.js"></script>
  <script src="js/jquery.easing.1.3.js"></script>
  <script src="js/aos.js"></script>
  
  <script src="js/main.js"></script>
    
</body>
</html>

<?php 
if (isset($_REQUEST['signin-confirm'])) {

  $url = "http://makievksy.ru.com/User";

  $array = json_encode(array(
    "firstName"    => $_POST['nameUser'],
    "middleName" => $_POST['lastNameUser'],
    "lastName" => $_POST['surnameUser'],
    "roleId" => 1,
    "countryId" => 1,
    "ipAddress" => $_SERVER['REMOTE_ADDR'],
    "regionId" => 1,
    "login" => $_POST['login'],
    "password" => $_POST['password'],
    "lawFirmId" => null,
    "email" => $_POST['sendEmail'],
    "phone" => $_POST['phoneUser']

  ));		
   
  $ch = curl_init($url);
  curl_setopt($ch, CURLOPT_POST, 1);
  curl_setopt($ch, CURLOPT_POSTFIELDS, $array); 
   
  curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
  curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
  curl_setopt($ch, CURLOPT_HEADER, false);
  curl_setopt($ch, CURLOPT_HTTPHEADER,
    array(
        'Content-Type:application/json',
        'Accept: text/plain'
    )
  );  
  $html = curl_exec($ch);
  $status = curl_getinfo($ch, CURLINFO_HTTP_CODE);

  curl_close($ch);
  
  $token = json_decode($html);
  $succsessToken = $token->data;

  $email = $_REQUEST['sendEmail'];
  $headers  = "MIME-Version: 1.0\r\n";
  $headers .= "Content-type: text/html; charset=utf-8\r\n";
  $headers .= "From: <service@sbercloud.codechallenge.life>\r\n";
  $message = '
              <html>
                  <head>
                      <title>Токен для приложения</title>
                  </head>
                  <body>  Токен для доступа: '.hash('sha256', $succsessToken). '        
                  </body>
              </html>
              ';
                      if (mail($email, "Token :: Sbercloud :: easy4 :: Токен для доступа в чат", $message, $headers)) {
                            ?>
                                <script>
                                    alert("На ваш емейл отправляется уникальный ключ-токен.");
                                    window.location.replace("https://sbercloud.codechallenge.life/");
                                </script>
                            <?php
                    }
        }
?>