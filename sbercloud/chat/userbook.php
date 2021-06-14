<?php
session_start();
$urlProject = "http://makievksy.ru.com/Chat?userId=".$_SESSION['Id'];

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

  $getData = json_decode(get_project($urlProject), true);
?>




<header>Чаты</header>
<div >
    <input type="text" size="40" placeholder="Поиск сообщений по пользователям..." class="txt-search">
</div>
<div style="padding-left:15px;">
    <div>
        <?php
        $total = 1;
        for ($i=0; $i < count($getData[$i]["chat"]); $i++) { 
             $total += $i;
             echo "<div style='display: inline-block;margin:5px;'>";
             echo '<img src="https://vokrug.tv/pic/news/9/f/4/6/9f466307ab9f357c0db710631834bc95.jpg" class="dot-pic beauty-btn"/>';
             echo "<br/>";
             echo "<center>".$getData[$i]["chat"]["name"]."</center>";
             echo "</div>";
        }

        ?>
    </div>

    <div>
    <?php 
     for ($i=0; $i < count($getData[$i]["chat"]); $i++) {
    ?>
        <a href="#">
            <div class="data-message beauty-btn">
                <div>
                    <div style="display:inline-block;" class="dot-pic"></div>
                    <div style="display:inline-block;">
                        <p><?php echo $getData[$i]["user"]["firstName"]." ".$getData[$i]["user"]["lastName"]." ".$getData[$i]["user"]["middleName"] ?></p>
                        <p>Сообщения в переписке</p>
                    </div>
                </div>
            </div>
        </a>
    </div>
    <?php
     }
    ?>
</div>