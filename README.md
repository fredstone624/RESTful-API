# RESTful-API with .NET Core

### Used libraries:
* **Entity Framework Core**
* **AutoMapper**


### Examples:
#### Request: **get** `/api/albums`
#### Response: 
```json
[
    {
        "id": "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
        "name": "Album 1",
        "description": "Desc 1"
    },
    {
        "id": "b392f290-0e40-44a5-962b-4093cc31f65d",
        "name": "Album 2",
        "description": null
    }
]
```

#### Request: **get** `/api/albums/3fdaec2a-be17-4c3c-b50e-72ff0eec2440`
#### Response: 
```json
{
    "id": "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
    "name": "Album 1",
    "description": "Desc 1"
}
```


#### Request: **get** `/api/photos`
#### Response: 
```json
[
    {
        "id": "462e23ca-f944-49f2-bcb5-4be963b1a327",
        "albumId": "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
        "imageId": "1eca8c4c-c7c0-447f-9287-f451c0520c28"
    },
    {
        "id": "e2193657-e924-4967-99ce-adc3d0daa9de",
        "albumId": "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
        "imageId": "bdbb4f26-ae4b-4a29-a5b0-8ae4fad81845"
    }
]
```


#### Request: **get** `/api/images`
#### Response: 
```json
[
    {
        "id": "1eca8c4c-c7c0-447f-9287-f451c0520c28",
        "url": "https://avatars.mds.yandex.net/get-pdb/1105309/b26948f0-22ce-41a3-a690-770e9cbf92ce/s1200",
        "photoId": "462e23ca-f944-49f2-bcb5-4be963b1a327"
    },
    {
        "id": "bdbb4f26-ae4b-4a29-a5b0-8ae4fad81845",
        "url": "https://avatars.mds.yandex.net/get-pdb/805781/e9f31bb4-e65d-4ccf-8a5f-36b74d8a75be/s1200",
        "photoId": "e2193657-e924-4967-99ce-adc3d0daa9de"
    }
]
```
