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