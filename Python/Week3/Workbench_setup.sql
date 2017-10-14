USE twitter;
SELECT *
FROM tweets
INSERT INTO `twitter`.`tweets` (`tweet`, `user_id`, `created_at`, `updated_at`) VALUES ('Roawr!', '1', '2014-02-01 00:00:01', '2014-02-01 00:00:01');
UPDATE `twitter`.`tweets` SET `tweet`='Silly Me! ' WHERE `id`='16';
DELETE FROM `twitter`.`tweets` WHERE `id`='16';