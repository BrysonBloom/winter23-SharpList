CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS cars(
  id INT AUTO_INCREMENT  PRIMARY KEY,
  make VARCHAR(50) NOT NULL COMMENT 'the make of the car, you know like honda or something.',
  model VARCHAR(50) NOT NULL,
  year INT NOT NULL DEFAULT 2025,
  price DOUBLE NOT NULL DEFAULT 1.00,
  description TEXT,
  imgUrl VARCHAR(255) NOT NULL,
  color VARCHAR(15)
)default charset utf8 COMMENT '';
DROP table IF EXISTS cars;

-- ALTER TABLE cars we can alter but lets not right now, jus drop and re-create
-- MODIFY COLUMN id

INSERT INTO cars
(make, model, year, price, imgUrl, color, description)
VALUES
('honda', 'Other THing', 2024, 87.99, 'https://www.cnet.com/a/img/resize/0f06571d98e478682454ee14e0a2a8c47cf11bc9/hub/2019/11/01/bf19e904-80c3-4b12-997a-a180557504b3/01-2020-honda-cr-v-dream-build-by-jsport-for-2019-sema-show.jpg?auto=webp&width=1200', '#fff', "It's certainly something, it's got wheels, and glass");
  INSERT INTO cars
  (make, model, year, price, imgUrl, color, description)
  VALUES
  ('Sierra', 'toyota', 2025, 7.99, 'https://s1.cdn.autoevolution.com/images/news/2025-toyota-stout-makes-digitally-rugged-comeback-to-scare-the-mavericks-away-210858_1.jpg', '#0000ff', "It's a blue truck");
  INSERT INTO cars
  (make, model, year, price, imgUrl, color, description)
  VALUES
  ('Nissan', '35z', 2003, 799.99, 'https://hips.hearstapps.com/hmg-prod/amv-prod-cad-assets/images/05q2/267355/nissan-350z-35th-anniversary-edition-photo-5297-s-original.jpg', '#30fec5', "Need for speed underground.");

SELECT 
*
FROM cars
WHERE make LIKE '%r%' OR description LIKE '%speed%';

SELECT * FROM cars;

DELETE FROM cars WHERE make LIKE '&truck&';

DELETE FROM cars WHERE id = 5;

UPDATE cars
SET
make = 'monster truck',
model = 'civic',
year = 2022
WHERE make = 'monster truck';
UPDATE cars
SET
id = 60,
make = 'monster truck',
model = 'civic',
year = 2022
WHERE id = 36;


SELECT LAST_INSERT_ID();