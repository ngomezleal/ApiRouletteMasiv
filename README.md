# ApiRouletteMasiv
API representing an online betting roulette. The API is developed in .Net core 5 and database sql server express edition.

## Install
	1.- Change connection string in appsettings.json
	2.- Execute commands for migration
		add-migration identity
		update-database

## Steps
	1.- Create User. It return a token for be used in other endpoints.
	2.- Create Wallet. It register wallet value.
	3.- Register New Roulette.
	4.- Open Roulette With Id Returned in Step 3
	4.- Start Bet With some parameters, including the Id Returned in Step 3
	5.- Close Bet with Id Returned in Step 3
	6.- Get All Roulettes.

## Important
	1.- The steps 2 to the 6, is required the use of Authorization Token of type "Bearer Token".
	2.- Can use Postman as client.
	3.- If token expired, then, can sign in and get it.

## URLs (EndPoints)
_1.- Account_

_.-Create User_

_[POST] host:port/api/account/CreateUser | Example: https://localhost:44302/api/account/CreateUser_ 

	"Body Params" (Example)
	{
	  "email": "example@email.com",
	  "password": "123456"
	}

	"Result" (Example)
	{
	  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im5nb21lemxlYWwzQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJuZ29tZXpsZWFsM0BnbWFpbC5jb20iLCJVc2VySWQiOiI1YjU4Y2Q2Zi04ZmRhLTQxNTktOWY4MS1jN2ZlMzZjZThiNGUiLCJqdGkiOiJmNDNmMDY4MC1mOTI3LTQ0NDAtOTFlMS04OGNkN2VhODBlZDYiLCJleHAiOjE2MzYyNjk1OTQsImlzcyI6ImRvbWFpbi5jb20iLCJhdWQiOiJkb21haW4uY29tIn0.JgMOFQeCG5EljzMs2Fk4J0HsytOwvltPw2n2vBws6mU",
	  "expiration": "2021-11-07T07:19:54.0400554Z",
	  "status": true
	}

_.-Login User_

_[POST] host:port/api/account/LoginUser | Example: https://localhost:44302/api/account/LoginUser_ 

	"Body Params" (Example)
	{
	  "email": "example@email.com",
	  "password": "123456"
	}

	"Result" (Example)
	{
	  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im5nb21lemxlYWwzQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJuZ29tZXpsZWFsM0BnbWFpbC5jb20iLCJVc2VySWQiOiI1YjU4Y2Q2Zi04ZmRhLTQxNTktOWY4MS1jN2ZlMzZjZThiNGUiLCJqdGkiOiJmNDNmMDY4MC1mOTI3LTQ0NDAtOTFlMS04OGNkN2VhODBlZDYiLCJleHAiOjE2MzYyNjk1OTQsImlzcyI6ImRvbWFpbi5jb20iLCJhdWQiOiJkb21haW4uY29tIn0.JgMOFQeCG5EljzMs2Fk4J0HsytOwvltPw2n2vBws6mU",
	  "expiration": "2021-11-07T07:19:54.0400554Z",
	  "status": true
	}

_2.- Wallet_

_.-Create Wallet_

_[POST] host:port/api/Wallet/CreateWallet | Example: https://localhost:44302/api/Wallet/CreateWallet_ 
	
	**Token Required**

	"Body Params" (Example)
	{
	  "total": 20000,
	}

	"Result" (Example)
	{
	  "id": 18,
	  "userId": "67a60e4e-1daf-47f8-8bd6-228e981ef897",
	  "total": 20000,
	  "trace": "2021-11-06T17:37:54.1498929Z"
	}

_3.- Roulette_

_.-New Roulette_

_[POST] host:port/api/Roulette/NewRoulette | Example: https://localhost:44302/api/Roulette/NewRoulette_ 
	
	**Token Required**

	"Result" (Example)
	{
	  "idRoulette": 13
	}

_.-Open Roulette_

_[PUT] host:port/api/Roulette/OpenRoulette/{Id} | Example: https://localhost:44302/api/Roulette/OpenRoulette/13_ 
	
	**Token Required**

	"Result" (Example)
	{
	  "status": "Success"
	}

_.-Gell All Roulettes_

_[GET] host:port/api/Roulette/GetAllRoulette | Example: https://localhost:49153/api/Roulette/GetAllRoulette_ 
	
	**Token Required**

	"Result" (Example)
	{
	  "roulettes": [
	  {
	    "id": 14,
		"status": "Close",
		"openAt": "2021-11-07T07:15:44.3748212",
		"closeAt": "2021-11-07T07:17:13.7101721",
		"trace": "2021-11-07T07:15:19.0755572"
      }
     ]
    }

_4.- Bet_

_.-Start Bet_

_[POST] host:port/api/Bet/StartBet | Example: https://localhost:44302/api/Bet/StartBet_ 
	
	**Token Required**

	"Body Params" (Example 1)
	{
	  "IdRoulette": 13,
	  "BetValue" : "Red",
	  "BetAmount" : 3500
	}

	"Body Params" (Example 2)
	{
	  "IdRoulette": 13,
	  "BetValue" : "21",
	  "BetAmount" : 3500
	}
	--

	"Result" (Example)
	{
	  "status": "Success"
	}

_.-Close Bet_

_[POST] host:port/api/Bet/CloseBet/{Id} | Example: https://localhost:44302/api/Bet/CloseBet/13_ 
	
	**Token Required**

	"Result" (Example)
	{
	  "results": {
	    "status": "Success",
		  "bets": [
            {
			  "id": 12,
			  "idRoulette": 14,
			  "betAmount": 3500.000000,
			  "betValue": "Red",
			  "status": "Loser",
			  "trace": "2021-11-07T07:16:10.6490759"
            }
         ]
      }
	}