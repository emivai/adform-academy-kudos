INSERT INTO public.employee
(name, surname)
VALUES('Jonas', 'Jonaitis');

INSERT INTO public.employee
(name, surname)
VALUES('Petras', 'Petraitis');

INSERT INTO public.employee
(name, surname)
VALUES('Ieva', 'Ievaite');

INSERT INTO public.kudos
(sent, reason, "content", exchanged, sender_id, receiver_id)
VALUES('2022-12-09', 1, 'You are doing great!', FALSE, 1, 2);

INSERT INTO public.kudos
(sent, reason, "content", exchanged, sender_id, receiver_id)
VALUES('2022-12-10', 2, 'You are doing great!', TRUE, 2, 1);

INSERT INTO public.kudos
(sent, reason, "content", exchanged, sender_id, receiver_id)
VALUES('2022-12-11', 3, 'You are doing great!', FALSE, 3, 1);