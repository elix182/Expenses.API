CREATE TABLE expenses(
	expense_uid VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT (UUID()),
	description VARCHAR(256) NOT NULL,
	amount DECIMAL(18, 2) NOT NULL,
	date DATE NOT NULL,
	inserted_date DATETIME NULL,
	inserted_by VARCHAR(128) NULL,
	updated_date DATETIME NULL,
	updated_by VARCHAR(128) NULL
);