# ContactRest
A simple C# Web Api CRUD with SQL Server

# Get Contacts
GET - http://localhost/ContactRest/api/Contact/contacts
Response:
```json
{
    "contacts": [
        {
            "id": 1,
            "firstName": "Jane",
            "lastName": "Doe"
        },
        {
            "id": 2,
            "firstName": "John",
            "lastName": "Doe"
        }
    ]
}
```

# Get Contact by Id
GET - http://localhost/ContactRest/api/Contact/contacts?id=1
Response:
```json
{
    "id": 1,
    "firstName": "Jane",
    "lastName": "Doe"
}
```

# Add Contact
POST - http://localhost/ContactRest/api/Contact/contacts
Body - ```json {"firstName":"Jane", "lastName" : "Doe"} ```
Response: 1 (integer)


# Edit Contact
PUT - http://localhost/ContactRest/api/Contact/contacts
Body - ```json {"id" : 1, "firstName":"Jane", "lastName" : "Doe"} ```
Response:
```json
{
    "id": 1,
    "firstName": "Jane Edited",
    "lastName": "Doe Edited"
}
```

# Delete Contact
DELETE - http://localhost/ContactRest/api/Contact/contacts?id=1
Response: true OR false (bool)