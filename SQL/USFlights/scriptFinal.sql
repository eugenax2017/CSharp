use usairlineflights2;
-- 1 --
-- SELECT count(*) as TOTAL from flights;
-- 2 --
-- SELECT Origin, sum(ArrDelay)/count(ArrDelay) as prom_arribades, sum(DepDelay)/count(DepDelay) as prom_sortides from flights
-- group by Origin;
-- 3 --
-- SELECT Origin, colYear, colMonth, sum(ArrDelay)/count(ArrDelay) as prom_arribades from flights
-- group by Origin, colYear, colMonth
-- order by Origin;
-- 4 --
-- SELECT usairports.City, colYear, colMonth, sum(ArrDelay)/count(ArrDelay) as prom_arribades from flights
-- inner join usairports on Origin = IATA
-- group by City, colYear, colMonth
-- order by City;
-- 5 --
-- SELECT UniqueCarrier, colYear, colMonth, sum(ArrDelay)/count(ArrDelay) as avg_delay, sum(Cancelled) as total_cancelled from flights
-- group by UniqueCarrier, colYear, colMonth
-- HAVING total_cancelled > 0
-- order by total_cancelled DESC;
-- 6 --
-- SELECT TailNum, sum(Distance) as totalDistance from flights
-- where TailNum <> "" 
-- group by TailNum
-- order by totalDistance DESC
-- LIMIT 10;
-- 7 --
SELECT UniqueCarrier, sum(ArrDelay)/count(ArrDelay) as avg_delay from flights
group by UniqueCarrier
HAVING avg_delay > 0
order by avg_delay desc;




