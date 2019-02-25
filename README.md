# RESTful-API with .NET Core

### Used libraries:
* **Entity Framework Core**
* **AutoMapper**


### Examples:
#### Request: `/api/albums`
#### Response: 
```json
[
    {
        "id": "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
        "name": "Album 1",
        "description": "Desc 1",
        "numberOfVisitor": 1
    },
    {
        "id": "b392f290-0e40-44a5-962b-4093cc31f65d",
        "name": "Album 2",
        "description": null,
        "numberOfVisitor": 2
    }
]
```

#### Request: `/api/albums/3fdaec2a-be17-4c3c-b50e-72ff0eec2440`
#### Response: 
```json
{
    "id": "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
    "name": "Album 1",
    "description": "Desc 1",
    "numberOfVisitor": 1
}
```


#### Request: `/api/photos`
#### Response: 
```json
[
    {
        "id": "462e23ca-f944-49f2-bcb5-4be963b1a327",
        "image": {
            "id": "1eca8c4c-c7c0-447f-9287-f451c0520c28",
            "bytes": "",
            "mimeType": null
        },
        "album": {
            "id": "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
            "name": "Album 1",
            "description": "Desc 1",
            "numberOfVisitor": 1
        }
    },
    {
        "id": "e2193657-e924-4967-99ce-adc3d0daa9de",
        "image": {
            "id": "bdbb4f26-ae4b-4a29-a5b0-8ae4fad81845",
            "bytes": "",
            "mimeType": null
        },
        "album": {
            "id": "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
            "name": "Album 1",
            "description": "Desc 1",
            "numberOfVisitor": 1
        }
    }
]
```


#### Request: `/api/images`
#### Response: 
```json
[
    {
        "id": "1eca8c4c-c7c0-447f-9287-f451c0520c28",
        "bytes": "",
        "mimeType": null,
        "photoId": "462e23ca-f944-49f2-bcb5-4be963b1a327"
    },
    {
        "id": "bdbb4f26-ae4b-4a29-a5b0-8ae4fad81845",
        "bytes": "",
        "mimeType": null,
        "photoId": "e2193657-e924-4967-99ce-adc3d0daa9de"
    }
]
```
