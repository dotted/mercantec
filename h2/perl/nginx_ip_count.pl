#!/usr/bin/perl
use strict;
use warnings;

use Path::Class;
use autodie; # die if problem reading or writing a file

my $dir = dir("/var/log/nginx");

my $file = $dir->file("access.log");

# openr() returns an IO::File object to read from
my $file_handle = $file->openr();

#Empty associative array
my %ip_addresses = ();

# Read in line at a time
while( my $line = $file_handle->getline() ) {
    if ( $line =~ m/^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})/ ) {
        $ip_addresses{"$1.$2.$3.$4"}++;
    }
}

#Crazy syntax
foreach my $key (sort {$ip_addresses{$a} <=> $ip_addresses{$b}} keys %ip_addresses) {
    print "$key: " . $ip_addresses{$key} . "\n";
}