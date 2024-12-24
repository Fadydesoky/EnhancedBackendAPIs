#!/bin/bash

echo "Testing REST API"
echo "================"
echo "Get all users:"
curl -X GET http://localhost:5147/api/users
echo -e "\n\nGet user with ID 1:"
curl -X GET http://localhost:5147/api/users/1
echo -e "\n\nCreate new user:"
curl -X POST http://localhost:5147/api/users \
     -H "Content-Type: application/json" \
     -d '{"name": "New User", "email": "newuser@example.com"}'

echo -e "\n\nTesting SOAP API"
echo "================"
echo "Get user with ID 1:"
curl -X POST http://localhost:5269/UserService.asmx \
     -H "Content-Type: text/xml" \
     -d @- <<EOF
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetUser xmlns="http://example.com/soap">
      <id>1</id>
    </GetUser>
  </soap:Body>
</soap:Envelope>
EOF

echo -e "\n\nGet all users:"
curl -X POST http://localhost:5002/UserService.asmx \
     -H "Content-Type: text/xml" \
     -d @- <<EOF
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetAllUsers xmlns="http://example.com/soap" />
  </soap:Body>
</soap:Envelope>
EOF

echo -e "\n\nTesting gRPC API"
echo "================"
echo "Get user with ID 1:"
grpcurl -plaintext -d '{"id": 1}' localhost:5115 user.UserService/GetUser

echo -e "\n\nGet all users:"
grpcurl -plaintext localhost:5115 user.UserService/GetAllUsers

