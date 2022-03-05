
---------------- Start savesurvivors --------------------
{
  "survivors": {
    "id": 0,
    "name": "Girish",
    "age": 50,
    "gender": "male",
    "flag": false,
    "water": 100,
    "food": "rice",
    "medication": "pcm",
    "ammunition": 100
  },
  "survivorLocation": {
    "id": 0,
    "latitude": "100",
    "longitude": "150",
    "survivorId": 0
  }
}

--- Response 

{
  "survivors": {
    "id": 5,
    "name": "Girish",
    "age": 50,
    "gender": "male",
    "flag": false,
    "water": 100,
    "food": "rice",
    "medication": "pcm",
    "ammunition": 100
  },
  "survivorLocation": {
    "id": 4,
    "latitude": "100",
    "longitude": "150",
    "survivorId": 5
  }
}



---------------- END  for savesurvivors --------------------


------------------------------ Status Start
{
  "id": 5,  
  "flag": true  
}

------------------- Status End



-------------------- updatesurvivorlocation -----------------
{
 
  "latitude": "250",
  "longitude": "100",
  "survivorId": 5
}


-------------------- End updatesurvivorlocation -----------------


you can call above api from swagger.

DB script also attached.
