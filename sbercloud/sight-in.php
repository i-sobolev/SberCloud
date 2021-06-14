<?php
session_start();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <link href="https://fonts.googleapis.com/css?family=Rubik:300,400,700|Oswald:400,700" rel="stylesheet">
    <link rel="stylesheet" type="./text/css" href="../chat/design/my.css">
    <link rel="stylesheet" href="./fonts/icomoon/style.css">

    <link rel="stylesheet" href="./css/bootstrap.min.css">
    <link rel="stylesheet" href="./css/jquery.fancybox.min.css">
    <link rel="stylesheet" href="./css/owl.carousel.min.css">
    <link rel="stylesheet" href="./css/owl.theme.default.min.css">
    <link rel="stylesheet" href="./fonts/flaticon/font/flaticon.css">
    <link rel="stylesheet" href="./css/aos.css">
    
    <link rel="stylesheet" href="./css/style.css">
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

    <div class="site-section">
      <div class="block__73694 mb-2" id="services-section">
        <div class="container">
          <div class="row d-flex no-gutters align-items-stretch">

            <div class="col-12 col-lg-6 block__73422" style="background-size: auto;background-image: url('./logo.png');" data-aos="fade-right" data-aos-delay="">
            </div>

            

            <div class="col-lg-5 ml-auto p-lg-5 mt-4 mt-lg-0" data-aos="fade-left" data-aos-delay="">
            
              <h2 class="mb-3 text-black">Войти в приложение чата</h2>
              
                <p>
                <form class="form-block" action="" method="post">
                    <label style="width:80px;">Email:</label>
                    <input class="input-signin" type="text" name="login" placeholder="Введите Email...">
                    <br/>
                    <label style="width:80px;">Пароль:</label>
                   
                    <input class="input-signin" type="password" name="password" placeholder="Введите пароль...">
                    <br/>
                    <button type="submit" class="brn" id="signin-button" name="signin-confirm" onclick="">Войти</button>
                    <button type="submit" class="brn" id="signin-button" name="signin-confirm-sber" onclick="">Sberbank ID</button>

                    <label style="width:100px;">Логин: test</label>
                    <label style="width:100px;">Пароль: test</label>
                </form>
                </p>
            </div>

          </div>
        </div>      
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
  $urlProject = "http://makievksy.ru.com/Auth?login=".$_POST['login']."&password=".$_POST['password'];
                
  function get_project($urlProject) { 
        $ch = curl_init(); 
 
        curl_setopt_array($ch,[
          CURLOPT_AUTOREFERER => true,
          CURLOPT_HEADER => false,
          CURLOPT_RETURNTRANSFER => true,
          CURLOPT_URL => $urlProject,
          CURLOPT_FOLLOWLOCATION => true,
          CURLOPT_HTTPHEADER => [
            'Content-Type: application/json'           
          ]
        ]);
        
        $data = curl_exec($ch);
        curl_close($ch); 
        return $data; 
    }
 
 //    $step = 1;
  $getData = json_decode(get_project($urlProject), true);
  if($getData != null){
    $_SESSION['Id'] = $getData['id'];
    ?>
    <script>
    setTimeout(function () {
      window.location.href = "../chat/chatroom";
        }, 1000);
    </script>
    <?php
  }
  else{
    echo "<center><h1>Такого пользователя нет.</h1></center>";
   
  }
  }
?>