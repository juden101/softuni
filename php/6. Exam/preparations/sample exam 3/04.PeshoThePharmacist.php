<?php

date_default_timezone_set('UTC');

$today = $_GET['today'];
$invoicesInput = $_GET['invoices'];
$invoices = [];

$splitToday = explode('/', $today);
$today = $splitToday[1] . '/' . $splitToday[0] . '/' . $splitToday[2];
$todayTimestamp = strtotime($today);

$fiveYearsBack = strtotime('-5 years', $todayTimestamp);

foreach($invoicesInput as $invoice) {
    if($invoice != null) {
        $slitInvoice = explode('|', $invoice);

        $invoiceTimestamp = trim($slitInvoice[0]);
        $splitInvoiceTimestamp = explode('/', $invoiceTimestamp);
        $invoiceTimestamp = $splitInvoiceTimestamp[1] . '/' . $splitInvoiceTimestamp[0] . '/' . $splitInvoiceTimestamp[2];
        $invoiceTimestamp = strtotime($invoiceTimestamp);
        $invoiceCompany = trim($slitInvoice[1]);
        $invoiceDrug = trim($slitInvoice[2]);
        $invoiceCost = trim($slitInvoice[3]);

        if($invoiceTimestamp >= $fiveYearsBack) {
            $invoices[$invoiceTimestamp][$invoiceCompany][] = [ 'drug' => $invoiceDrug, 'cost' => $invoiceCost ];
        }
    }

}

ksort($invoices);

foreach($invoices as $key => $invoice) {
    ksort($invoices[$key]);
}

echo '<ul>';
foreach($invoices as $timestampKey => $timestamp) {
    echo '<li><p>' . date('d/m/Y', $timestampKey) . '</p>';
    foreach($timestamp as $companyKey => $company) {
        echo '<ul>';
        echo '<li><p>' . $companyKey . '</p>';
        echo '<ul>';
        $products = [];
        $price = 0;

        usort($invoices[$timestampKey][$companyKey], function($a, $b) {
            return strcasecmp($a['drug'], $b['drug']);
        });

        foreach($company as $keyInvoice => $invoice) {
            $products[] = $invoices[$timestampKey][$companyKey][$keyInvoice]['drug'];

            preg_match('/[\d]+[\.\d]*/', $invoice['cost'], $cost);
            $price += $cost[0];
        }
        echo '<li><p>' . implode(',', $products) . '-' . $price . 'lv</p></li>';
        echo '</ul>';
        echo '</li>';
        echo '</ul>';
    }
    echo '</li>';
}
echo '</ul>';