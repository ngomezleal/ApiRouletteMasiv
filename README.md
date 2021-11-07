# ApiRouletteMasiv
API representing an online betting roulette. The API is developed in .Net core 5 and database sql server express edition.

## Install
	1.- Change connection string in appsettings.json
	2.- Execute commands for migration
		add-migration identity
		update-database

## URLs (EndPoints)
_1.- Account_

_Create User_

_[POST] host:port/api/account/CreateUser | Example: https://localhost:44302/api/account/CreateUser_ 

		_BODY PARAMS_

		{
			"email": "example@email.com",
			"password": "123456"
		}

		_Result (Example)_
		{
			"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im5nb21lemxlYWwzQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJuZ29tZXpsZWFsM0BnbWFpbC5jb20iLCJVc2VySWQiOiI1YjU4Y2Q2Zi04ZmRhLTQxNTktOWY4MS1jN2ZlMzZjZThiNGUiLCJqdGkiOiJmNDNmMDY4MC1mOTI3LTQ0NDAtOTFlMS04OGNkN2VhODBlZDYiLCJleHAiOjE2MzYyNjk1OTQsImlzcyI6ImRvbWFpbi5jb20iLCJhdWQiOiJkb21haW4uY29tIn0.JgMOFQeCG5EljzMs2Fk4J0HsytOwvltPw2n2vBws6mU",
			"expiration": "2021-11-07T07:19:54.0400554Z",
			"status": true
		}