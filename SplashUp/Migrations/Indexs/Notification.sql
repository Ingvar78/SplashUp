CREATE INDEX ns_pfhd
    ON public.notifications USING btree
    (purchase_num ASC NULLS LAST, hash ASC NULLS LAST, fz_type ASC NULLS LAST, publish_date ASC NULLS LAST)
;

CREATE INDEX ns_cfhd
    ON public.contracts USING btree
    (contract_num ASC NULLS LAST, hash ASC NULLS LAST, fz_type ASC NULLS LAST, publish_date ASC NULLS LAST)
;


CREATE INDEX ns_prfhd
    ON public.protocols USING btree
    (protocol_num ASC NULLS LAST, hash ASC NULLS LAST, fz_type ASC NULLS LAST, publish_date ASC NULLS LAST)
;

COMMENT ON INDEX public.ns_prfhd
    IS 'Index for Protocols by hash, FZ, Date and protocol_num';