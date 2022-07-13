<?php

    #db configuration
    $servername = "localhost";
    $username = "35509824_sensor_db";
    $password = "sensordb11K";
    $dbname = "35509824_sensor_db";

    #detect http request and get body as json 
    $post = json_decode(file_get_contents('php://input'), true);
    if(json_last_error() == JSON_ERROR_NONE)
    {
        $token = $post["token"];
        if($token == "8ef050eb-9397-4ffb-b206-339e6fd85d7b"){
        
            #get value from json 
            $epochTime = $post["epochTime"];
            $value = $post["value"];
            
            #convert datetime form epoch time
            $dt = new DateTime("@$epochTime");
            $dateTime = $dt->format('Y-m-d H:i:s');
           
            #open connection to sql
            $conn = new mysqli($servername, $username, $password, $dbname);
            if ($conn->connect_error) {
                die("Connection failed: " . $conn->connect_error);
            }
           
            foreach ($value as $k=>$v){
            
                #get data from array
                $sensorId = $v["address"];
                $value = $v["tempC"];
                
                #create sql query
                $sql = "INSERT INTO `DataValueTick` (`Id`, `Token`, `DateTime`, `EpochTime`, `SensorId`, `Value`) VALUES (uuid(), '$token', '$dateTime', '$epochTime', '$sensorId', '$value')";
                
                #exec query
                if ($conn->multi_query($sql) === TRUE) {
                  echo "New records created successfully";
                } else {
                  echo "Error: " . $sql . "<br>" . $conn->error;
                }       
            }
            
            #close connection
            $conn->close();
                       
        } 
    }
?>