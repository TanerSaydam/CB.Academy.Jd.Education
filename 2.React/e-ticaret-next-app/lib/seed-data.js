import { connection } from "@/lib/db";
import Product from '@/models/product';

export async function seedProductData() {
	connection();
	var data = [
	  {
		id: "0dc3c8fa-21f3-4c97-8644-a067746ac4c3",
		name: "Awesome Frozen Mouse",
		imageUrl: "https://picsum.photos/640/480/?image=243",
		stock: 126,
		price: 75908.60
	  },
	  {
		id: "acf330ad-7100-4f88-b2c4-500d2b78245c",
		name: "Awesome Frozen Salad",
		imageUrl: "https://picsum.photos/640/480/?image=663",
		stock: 79,
		price: 87067.54
	  },
	  {
		id: "07e595a0-a93d-423e-88d0-54c8f6430834",
		name: "Awesome Frozen Table",
		imageUrl: "https://picsum.photos/640/480/?image=11",
		stock: 5,
		price: 63070.71
	  },
	  {
		id: "e78c7721-e9f4-43f9-9d3c-3a447bf66c2f",
		name: "Awesome Rubber Salad",
		imageUrl: "https://picsum.photos/640/480/?image=883",
		stock: 70,
		price: 35680.22
	  },
	  {
		id: "db253f9b-5ebd-48ec-92f2-600315e6c4ff",
		name: "Awesome Steel Gloves",
		imageUrl: "https://picsum.photos/640/480/?image=851",
		stock: 44,
		price: 79565.79
	  },
	  {
		id: "edf1a7a9-baa3-423b-a5f1-1348d5cab14d",
		name: "Awesome Wooden Shirt",
		imageUrl: "https://picsum.photos/640/480/?image=82",
		stock: 67,
		price: 120869.49
	  },
	  {
		id: "abc687aa-a226-473a-8794-9c11acab5148",
		name: "Ergonomic Fresh Fish",
		imageUrl: "https://picsum.photos/640/480/?image=634",
		stock: 24,
		price: 46737.30
	  },
	  {
		id: "beae3160-ae73-4a5f-aae6-c4cd77f7e7a4",
		name: "Ergonomic Fresh Towels",
		imageUrl: "https://picsum.photos/640/480/?image=1061",
		stock: 78,
		price: 71950.23
	  },
	  {
		id: "74a1ab10-e27a-4bed-b9aa-d10f382428c6",
		name: "Ergonomic Fresh Towels",
		imageUrl: "https://picsum.photos/640/480/?image=707",
		stock: 42,
		price: 32709.50
	  },
	  {
		id: "9d6134a5-c29b-4cc0-ab37-9340903d3cf1",
		name: "Ergonomic Frozen Pants",
		imageUrl: "https://picsum.photos/640/480/?image=204",
		stock: 135,
		price: 100043.00
	  },
	  {
		id: "729c7932-d2ce-4252-a909-d593bac5c0db",
		name: "Ergonomic Metal Shoes",
		imageUrl: "https://picsum.photos/640/480/?image=81",
		stock: 101,
		price: 77321.01
	  },
	  {
		id: "ec447a4b-1c48-4e2d-a7f0-e033508a4730",
		name: "Ergonomic Plastic Shirt",
		imageUrl: "https://picsum.photos/640/480/?image=991",
		stock: 113,
		price: 100448.99
	  },
	  {
		id: "9e2399ce-7408-4bbe-807e-0ca5b14a398d",
		name: "Ergonomic Rubber Tuna",
		imageUrl: "https://picsum.photos/640/480/?image=1018",
		stock: 67,
		price: 23840.48
	  },
	  {
		id: "5d5f350d-ef8a-4693-a4e5-f385a71c3f77",
		name: "Ergonomic Steel Bike",
		imageUrl: "https://picsum.photos/640/480/?image=1039",
		stock: 100,
		price: 86744.29
	  },
	  {
		id: "2723d4e2-49c1-4c25-a7ba-d9a69bc48e47",
		name: "Ergonomic Steel Chips",
		imageUrl: "https://picsum.photos/640/480/?image=690",
		stock: 59,
		price: 19612.75
	  },
	  {
		id: "f62705f3-3005-43c0-8ef6-850a3bbb3eb4",
		name: "Ergonomic Wooden Chicken",
		imageUrl: "https://picsum.photos/640/480/?image=692",
		stock: 32,
		price: 106040.41
	  },
	  {
		id: "03026629-6f55-4492-85b1-9bfcf37e7546",
		name: "Fantastic Granite Mouse",
		imageUrl: "https://picsum.photos/640/480/?image=323",
		stock: 3,
		price: 13676.90
	  },
	  {
		id: "9cc054eb-59a8-4461-a777-be220742c84f",
		name: "Fantastic Metal Hat",
		imageUrl: "https://picsum.photos/640/480/?image=895",
		stock: 96,
		price: 20534.97
	  },
	  {
		id: "628d73df-5965-400b-b17e-735c10b7b6dd",
		name: "Fantastic Metal Pants",
		imageUrl: "https://picsum.photos/640/480/?image=388",
		stock: 130,
		price: 40454.48
	  },
	  {
		id: "4c252ca1-6b17-46c1-a307-b7353b420632",
		name: "Fantastic Soft Pants",
		imageUrl: "https://picsum.photos/640/480/?image=69",
		stock: 30,
		price: 88523.65
	  },
	  {
		id: "476e6c50-780e-4c89-a6f4-b2b30455e0a9",
		name: "Generic Cotton Shirt",
		imageUrl: "https://picsum.photos/640/480/?image=902",
		stock: 70,
		price: 116074.08
	  },
	  {
		id: "07ce92a9-c512-4f12-a902-fa9aad032ca3",
		name: "Generic Granite Computer",
		imageUrl: "https://picsum.photos/640/480/?image=133",
		stock: 27,
		price: 53391.52
	  },
	  {
		id: "555e87c4-9016-4ee4-9fff-f6d9c496b01f",
		name: "Generic Soft Towels",
		imageUrl: "https://picsum.photos/640/480/?image=661",
		stock: 110,
		price: 1210.10
	  },
	  {
		id: "dea9ccd4-300a-4cdf-861b-42734141ae82",
		name: "Gorgeous Granite Soap",
		imageUrl: "https://picsum.photos/640/480/?image=914",
		stock: 116,
		price: 77751.19
	  },
	  {
		id: "558824f2-81de-4290-bcd9-f32890c4adfe",
		name: "Gorgeous Metal Chair",
		imageUrl: "https://picsum.photos/640/480/?image=1082",
		stock: 97,
		price: 55824.99
	  },
	  {
		id: "2123f810-c79c-4480-95ba-d2078e5619b3",
		name: "Handcrafted Concrete Tuna",
		imageUrl: "https://picsum.photos/640/480/?image=548",
		stock: 143,
		price: 106093.80
	  },
	  {
		id: "b37fe8c4-09bd-4334-a505-d07a051093ad",
		name: "Handcrafted Granite Chicken",
		imageUrl: "https://picsum.photos/640/480/?image=992",
		stock: 41,
		price: 94850.19
	  },
	  {
		id: "23e5162f-e615-4f79-acf9-6bc532b106b7",
		name: "Handcrafted Granite Chips",
		imageUrl: "https://picsum.photos/640/480/?image=262",
		stock: 82,
		price: 16131.11
	  },
	  {
		id: "5b868132-2b79-4971-a078-9abe8cd9ddcf",
		name: "Handcrafted Granite Salad",
		imageUrl: "https://picsum.photos/640/480/?image=982",
		stock: 53,
		price: 42553.91
	  },
	  {
		id: "1948f158-204a-4f93-a84f-10c27f0d7a9c",
		name: "Handcrafted Soft Cheese",
		imageUrl: "https://picsum.photos/640/480/?image=641",
		stock: 116,
		price: 69830.38
	  },
	  {
		id: "c7c6551a-e7ca-464b-aa8b-7ac728501f5e",
		name: "Handcrafted Soft Sausages",
		imageUrl: "https://picsum.photos/640/480/?image=952",
		stock: 21,
		price: 1948.22
	  },
	  {
		id: "73a588bc-102c-47e0-917b-40a5b9cf065d",
		name: "Handcrafted Steel Bacon",
		imageUrl: "https://picsum.photos/640/480/?image=245",
		stock: 103,
		price: 46271.77
	  },
	  {
		id: "3df52908-17ac-45dd-89bb-2f09c4eaf88f",
		name: "Handcrafted Steel Hat",
		imageUrl: "https://picsum.photos/640/480/?image=219",
		stock: 2,
		price: 107273.00
	  },
	  {
		id: "079146c6-8f11-40bb-8e2a-fa1f83851b71",
		name: "Handcrafted Steel Pants",
		imageUrl: "https://picsum.photos/640/480/?image=160",
		stock: 90,
		price: 49120.89
	  },
	  {
		id: "f86ab5ea-1421-4543-a981-81502380af4e",
		name: "Handcrafted Wooden Shoes",
		imageUrl: "https://picsum.photos/640/480/?image=827",
		stock: 35,
		price: 47988.26
	  },
	  {
		id: "01664a95-f6ed-4215-bf30-f4efda9872ba",
		name: "Handmade Fresh Towels",
		imageUrl: "https://picsum.photos/640/480/?image=380",
		stock: 143,
		price: 8023.48
	  },
	  {
		id: "b1994e0f-853f-4ca2-829d-dde1fa4ef5b7",
		name: "Handmade Granite Shoes",
		imageUrl: "https://picsum.photos/640/480/?image=109",
		stock: 132,
		price: 123935.84
	  },
	  {
		id: "9fa0748b-4624-41fa-b84f-d44253159440",
		name: "Handmade Soft Hat",
		imageUrl: "https://picsum.photos/640/480/?image=693",
		stock: 14,
		price: 48297.17
	  },
	  {
		id: "4e9d8438-ac18-4bba-b766-eb5bfe570d2a",
		name: "Incredible Metal Chair",
		imageUrl: "https://picsum.photos/640/480/?image=1037",
		stock: 64,
		price: 78813.75
	  },
	  {
		id: "de7e2091-6c47-43c8-8914-f3bbf3ff2520",
		name: "Incredible Metal Keyboard",
		imageUrl: "https://picsum.photos/640/480/?image=492",
		stock: 60,
		price: 102092.05
	  },
	  {
		id: "adc57c6f-088d-4a93-bdba-e5e3d5e4cf20",
		name: "Incredible Rubber Car",
		imageUrl: "https://picsum.photos/640/480/?image=530",
		stock: 50,
		price: 7772.77
	  },
	  {
		id: "2daca677-75f5-462f-9e26-f9fc5b90d867",
		name: "Incredible Soft Mouse",
		imageUrl: "https://picsum.photos/640/480/?image=521",
		stock: 97,
		price: 45186.50
	  },
	  {
		id: "0a5eb7f6-0287-416f-81a1-5ce41a9a8f7f",
		name: "Incredible Soft Table",
		imageUrl: "https://picsum.photos/640/480/?image=962",
		stock: 119,
		price: 114323.52
	  },
	  {
		id: "11230aba-5d51-4e46-a5a0-cb7aa648f0fc",
		name: "Incredible Steel Salad",
		imageUrl: "https://picsum.photos/640/480/?image=915",
		stock: 72,
		price: 51721.03
	  },
	  {
		id: "ecde51be-033a-4f68-a4d0-26203652a384",
		name: "Intelligent Cotton Mouse",
		imageUrl: "https://picsum.photos/640/480/?image=1057",
		stock: 148,
		price: 50713.85
	  },
	  {
		id: "ac4a5a09-416e-4c54-a200-8ccc3fef4b69",
		name: "Intelligent Granite Salad",
		imageUrl: "https://picsum.photos/640/480/?image=787",
		stock: 40,
		price: 53882.16
	  },
	  {
		id: "72512b96-8ffc-48da-b1d3-facf56ab5046",
		name: "Intelligent Metal Chair",
		imageUrl: "https://picsum.photos/640/480/?image=611",
		stock: 28,
		price: 81166.82
	  },
	  {
		id: "6fb200b8-94f4-4d0e-a71f-d98a1c9861e1",
		name: "Intelligent Rubber Keyboard",
		imageUrl: "https://picsum.photos/640/480/?image=856",
		stock: 85,
		price: 103389.88
	  },
	  {
		id: "254362ee-cb18-4616-a9dc-bf275ccd45b7",
		name: "Intelligent Soft Computer",
		imageUrl: "https://picsum.photos/640/480/?image=269",
		stock: 109,
		price: 70893.01
	  },
	  {
		id: "694d80b4-f5e6-49cb-8cbf-aad46c68f80c",
		name: "Intelligent Steel Sausages",
		imageUrl: "https://picsum.photos/640/480/?image=160",
		stock: 107,
		price: 81671.63
	  },
	  {
		id: "335bb9fe-c5a1-4581-a80b-b074f4ad4064",
		name: "Intelligent Wooden Pants",
		imageUrl: "https://picsum.photos/640/480/?image=579",
		stock: 53,
		price: 6200.42
	  },
	  {
		id: "0aa8db20-86f4-4aa4-a616-b6a5c8bbc8d5",
		name: "Licensed Concrete Pizza",
		imageUrl: "https://picsum.photos/640/480/?image=796",
		stock: 79,
		price: 86042.47
	  },
	  {
		id: "630439f0-9cfd-4efb-8dfd-13e0d6300d73",
		name: "Licensed Frozen Salad",
		imageUrl: "https://picsum.photos/640/480/?image=746",
		stock: 119,
		price: 29771.60
	  },
	  {
		id: "8d18202a-f2b9-4774-9e6e-0ae4d987a314",
		name: "Licensed Metal Chicken",
		imageUrl: "https://picsum.photos/640/480/?image=411",
		stock: 88,
		price: 25621.08
	  },
	  {
		id: "15452414-6cd4-4a10-856f-1bad5a03c440",
		name: "Licensed Metal Soap",
		imageUrl: "https://picsum.photos/640/480/?image=169",
		stock: 64,
		price: 95065.12
	  },
	  {
		id: "5ef7458f-6bc9-4bf8-9468-2cffe08d1370",
		name: "Licensed Steel Gloves",
		imageUrl: "https://picsum.photos/640/480/?image=77",
		stock: 95,
		price: 84036.92
	  },
	  {
		id: "b883aac0-3f53-4f5d-8f08-12aa1895d538",
		name: "Practical Fresh Table",
		imageUrl: "https://picsum.photos/640/480/?image=121",
		stock: 51,
		price: 107037.07
	  },
	  {
		id: "1452788d-a7e5-44bf-a208-f94a189ec939",
		name: "Practical Frozen Bacon",
		imageUrl: "https://picsum.photos/640/480/?image=1080",
		stock: 143,
		price: 40578.88
	  },
	  {
		id: "bb4b6369-1d33-4302-b8fa-5e9115b18d93",
		name: "Refined Concrete Bike",
		imageUrl: "https://picsum.photos/640/480/?image=221",
		stock: 117,
		price: 25515.15
	  },
	  {
		id: "ecbac54f-3cb6-4af5-82fc-823c320ed94e",
		name: "Refined Fresh Ball",
		imageUrl: "https://picsum.photos/640/480/?image=423",
		stock: 94,
		price: 108229.98
	  },
	  {
		id: "0b937903-9e61-4afe-b9f4-717dc79fa72f",
		name: "Refined Fresh Fish",
		imageUrl: "https://picsum.photos/640/480/?image=740",
		stock: 68,
		price: 56776.74
	  },
	  {
		id: "201a3a34-a14f-4f30-84cd-dca3f68140e3",
		name: "Refined Granite Mouse",
		imageUrl: "https://picsum.photos/640/480/?image=384",
		stock: 109,
		price: 85864.78
	  },
	  {
		id: "ba72494a-cb55-48f9-933c-581ab9cf7744",
		name: "Refined Soft Mouse",
		imageUrl: "https://picsum.photos/640/480/?image=16",
		stock: 136,
		price: 54633.26
	  },
	  {
		id: "bee7c3d2-1c90-4862-8f6a-6e588e6433a2",
		name: "Refined Steel Pants",
		imageUrl: "https://picsum.photos/640/480/?image=527",
		stock: 120,
		price: 63546.18
	  },
	  {
		id: "10feacb4-2370-454c-891a-9992a7342372",
		name: "Refined Wooden Keyboard",
		imageUrl: "https://picsum.photos/640/480/?image=255",
		stock: 150,
		price: 29478.20
	  },
	  {
		id: "935929e7-1d2d-4f14-b44c-dc9811eeb7e3",
		name: "Rustic Concrete Gloves",
		imageUrl: "https://picsum.photos/640/480/?image=382",
		stock: 52,
		price: 120930.42
	  },
	  {
		id: "91779475-4eda-4f90-b212-89b1ab1ece6e",
		name: "Rustic Cotton Soap",
		imageUrl: "https://picsum.photos/640/480/?image=245",
		stock: 116,
		price: 35479.50
	  },
	  {
		id: "a34b5800-54eb-4e00-ace6-21df3dc336a6",
		name: "Rustic Frozen Chair",
		imageUrl: "https://picsum.photos/640/480/?image=155",
		stock: 7,
		price: 58571.60
	  },
	  {
		id: "40e7a09e-2650-4400-8572-cee7a9f56d9d",
		name: "Rustic Rubber Shirt",
		imageUrl: "https://picsum.photos/640/480/?image=1025",
		stock: 133,
		price: 77846.84
	  },
	  {
		id: "c9fa91b2-0432-4ee7-93fd-32135d436306",
		name: "Sleek Cotton Bacon",
		imageUrl: "https://picsum.photos/640/480/?image=132",
		stock: 103,
		price: 69306.72
	  },
	  {
		id: "f8e26eac-4ab3-4a54-9e0a-208c941f5f85",
		name: "Sleek Metal Mouse",
		imageUrl: "https://picsum.photos/640/480/?image=597",
		stock: 68,
		price: 53173.27
	  },
	  {
		id: "69b4dfc5-54c6-42d5-a4b7-239ba207069b",
		name: "Sleek Plastic Keyboard",
		imageUrl: "https://picsum.photos/640/480/?image=1051",
		stock: 40,
		price: 111419.97
	  },
	  {
		id: "2239806c-9ca7-4de2-8c13-44a08b08061a",
		name: "Sleek Rubber Chips",
		imageUrl: "https://picsum.photos/640/480/?image=969",
		stock: 29,
		price: 1832.87
	  },
	  {
		id: "fddbff60-5640-462f-9f60-ac1daf40a479",
		name: "Sleek Soft Fish",
		imageUrl: "https://picsum.photos/640/480/?image=1070",
		stock: 28,
		price: 38603.58
	  },
	  {
		id: "514ca4dd-16ec-49c8-9f39-aaa43364bed6",
		name: "Sleek Soft Soap",
		imageUrl: "https://picsum.photos/640/480/?image=268",
		stock: 23,
		price: 100398.76
	  },
	  {
		id: "58ce54bf-5036-490b-ae3a-fbdc14f56c3a",
		name: "Sleek Steel Table",
		imageUrl: "https://picsum.photos/640/480/?image=830",
		stock: 144,
		price: 55271.16
	  },
	  {
		id: "442b4c0c-f5aa-470b-a924-397e55097f94",
		name: "Small Cotton Table",
		imageUrl: "https://picsum.photos/640/480/?image=347",
		stock: 82,
		price: 88498.95
	  },
	  {
		id: "6b41804e-aba6-4698-8c6c-7effff5ead65",
		name: "Small Frozen Shoes",
		imageUrl: "https://picsum.photos/640/480/?image=51",
		stock: 142,
		price: 24045.99
	  },
	  {
		id: "57f7e543-5dcb-470b-9368-fcc867e1092d",
		name: "Small Metal Computer",
		imageUrl: "https://picsum.photos/640/480/?image=295",
		stock: 25,
		price: 105865.44
	  },
	  {
		id: "ae47f8e9-44dc-4424-8e81-5df872db7fd9",
		name: "Small Plastic Shirt",
		imageUrl: "https://picsum.photos/640/480/?image=395",
		stock: 79,
		price: 47971.42
	  },
	  {
		id: "1ca7dfa4-1428-4ea9-a1a7-1f4fc7c46e4c",
		name: "Small Rubber Bike",
		imageUrl: "https://picsum.photos/640/480/?image=643",
		stock: 92,
		price: 59659.18
	  },
	  {
		id: "d5afacd5-e654-4384-bc00-47b130bfef25",
		name: "Small Rubber Towels",
		imageUrl: "https://picsum.photos/640/480/?image=312",
		stock: 36,
		price: 99912.60
	  },
	  {
		id: "6768ac14-4390-4ba1-8291-fc13c5761305",
		name: "Small Soft Bike",
		imageUrl: "https://picsum.photos/640/480/?image=416",
		stock: 94,
		price: 91910.75
	  },
	  {
		id: "e9a1d2f3-79ea-4c62-b578-95c97eb4e89c",
		name: "Small Steel Pizza",
		imageUrl: "https://picsum.photos/640/480/?image=341",
		stock: 106,
		price: 64356.63
	  },
	  {
		id: "4ee4b84c-98ba-49f8-b892-a4caf9d575e6",
		name: "Small Steel Salad",
		imageUrl: "https://picsum.photos/640/480/?image=382",
		stock: 31,
		price: 107823.65
	  },
	  {
		id: "e15e9277-dc07-4231-902f-2c5328d2f4cc",
		name: "Tasty Concrete Tuna",
		imageUrl: "https://picsum.photos/640/480/?image=32",
		stock: 33,
		price: 1460.02
	  },
	  {
		id: "f15cae50-5f56-4782-9e5b-a9246b381d5c",
		name: "Tasty Granite Mouse",
		imageUrl: "https://picsum.photos/640/480/?image=704",
		stock: 43,
		price: 37446.83
	  },
	  {
		id: "5be4c89b-3ad7-45b7-aff0-912018bae724",
		name: "Tasty Metal Computer",
		imageUrl: "https://picsum.photos/640/480/?image=830",
		stock: 140,
		price: 78411.93
	  },
	  {
		id: "36f04105-07d9-4d6b-aee0-9cbcfaca141d",
		name: "Tasty Metal Pants",
		imageUrl: "https://picsum.photos/640/480/?image=886",
		stock: 13,
		price: 92269.33
	  },
	  {
		id: "28ed5814-e60d-444f-8caf-66c33d0fef0f",
		name: "Tasty Rubber Chips",
		imageUrl: "https://picsum.photos/640/480/?image=703",
		stock: 136,
		price: 49366.22
	  },
	  {
		id: "74cce4e1-b56b-4657-9b21-c9e9a28ae207",
		name: "Tasty Steel Tuna",
		imageUrl: "https://picsum.photos/640/480/?image=352",
		stock: 29,
		price: 53781.75
	  },
	  {
		id: "0841a3b3-7074-41e1-a928-2b1548c140f8",
		name: "Unbranded Cotton Ball",
		imageUrl: "https://picsum.photos/640/480/?image=263",
		stock: 72,
		price: 11516.89
	  },
	  {
		id: "f2797fa2-3ffd-4333-9243-0ddd51cc77a9",
		name: "Unbranded Cotton Keyboard",
		imageUrl: "https://picsum.photos/640/480/?image=141",
		stock: 54,
		price: 108796.76
	  },
	  {
		id: "8678820c-fa2b-458e-81c8-a5f1602c4be1",
		name: "Unbranded Cotton Salad",
		imageUrl: "https://picsum.photos/640/480/?image=819",
		stock: 117,
		price: 101062.56
	  },
	  {
		id: "01dc57c9-8bec-420c-a1d2-3ab91ef4a728",
		name: "Unbranded Cotton Towels",
		imageUrl: "https://picsum.photos/640/480/?image=103",
		stock: 117,
		price: 48603.19
	  },
	  {
		id: "ff5c3d3b-9118-4f8f-bed4-3c79dbeeded3",
		name: "Unbranded Fresh Gloves",
		imageUrl: "https://picsum.photos/640/480/?image=1017",
		stock: 31,
		price: 64503.01
	  },
	  {
		id: "6cae86a5-ade3-457c-b7a4-0f885df25c86",
		name: "Unbranded Frozen Table",
		imageUrl: "https://picsum.photos/640/480/?image=1047",
		stock: 108,
		price: 96166.72
	  },
	  {
		id: "be6ec7b0-a2ea-40be-a19e-d67319b9877a",
		name: "Unbranded Metal Fish",
		imageUrl: "https://picsum.photos/640/480/?image=82",
		stock: 116,
		price: 7680.00
	  },
	  {
		id: "21ea1aec-b72e-4685-a95e-2c6d5554dfc7",
		name: "Unbranded Soft Cheese",
		imageUrl: "https://picsum.photos/640/480/?image=196",
		stock: 96,
		price: 56331.77
	  },
	  {
		id: "bc4f69ec-84a2-485c-8a7a-6ba7e1dfb8e7",
		name: "Unbranded Wooden Bike",
		imageUrl: "https://picsum.photos/640/480/?image=350",
		stock: 148,
		price: 21113.65
	  }
	]
  
	for(const val of data){ 
	  const product = new Product(val);
	  product.save();
	}  
  }