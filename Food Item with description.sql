Set identity_insert dbo.FoodItem ON
GO
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (1,'Hot Basil','Wok fried selected meat with basil leaves, garlic, chilli and seasonal vegetables',1);
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (2,'Oyster Sauce', 'Wok fried selected meat with vegetables and oyster sauce',1);
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (3,'Ginger', 'Wok fried selected meat with ginger, onion, and vegetables',1);
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (4,'Red Curry','Curry made out of coconut milk, red curry paste, selected meat and vegetables',2);
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (5,'Green Curry','Curry made out of coconut milk, green curry paste, selected meat and vegetables',2);
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (6,'Panaeng Curry','Curry made out of coconut milk, panaeng curry paste, selected meat, crushed peanut, lime leaves and vegetables',2);
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (7,'Tom Yum','Traditional hot and sour soup with Thai herbs, chilli paste, mushroom and tomato topped with corainder and spring onion',3);
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (8,'Pad Thai','Wok fried rice noodles with selected meat, egg, bean sprouts, spring onion, tofu, and crushed peanut',4);
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (9,'Rad Nar','Wok fried flat rice noodles with selected meat, gravy and vegetables',4);
insert into dbo.FoodItem(FoodItemId, FoodName,FoodDetail,FoodTypeId)
Values (10,'Larb','Minced selected meat with Thai herbs, chilli powder, red onion, mint leaves, spring onion, and corainder',5);
GO
Set identity_insert dbo.FoodItem Off
GO