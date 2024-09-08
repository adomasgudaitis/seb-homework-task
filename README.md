# SEB Homework Assignment

Task: 

1. Create an .net8 asp.net app that gets data from external URL
(https://get.data.gov.lt/datasets/gov/lgt/potencialus_tarsos_zidiniai/TarsosZidinys/:f
ormat/json) every day at 1 o’clock in the morning (+-1min) and saves to database. (for simplicity
use in memory database)
2. Use Entity Framework
3. User will integrate with your app through REST API (One GET method). (Data must be accessible all
the time)
4. User wants that data would be grouped by (ptz_objekto_tipas) and each group includes number of
grouped elements.
5. Code must comply with DDD (domain driven design) or layered structure architecture (do one or
another, not both)
6. Add logging.
7. Add middleware to log bad requests from HttpClient side.
8. Put code in git repository.
