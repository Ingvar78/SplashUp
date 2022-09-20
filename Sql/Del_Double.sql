--Удаление дублей
DELETE FROM protocols  a USING (
      SELECT MIN(ctid) as ctid, hash
        FROM protocols 
        GROUP BY hash HAVING COUNT(*) > 1
      ) b
      WHERE a.hash  = b.hash
      AND a.ctid <> b.ctid