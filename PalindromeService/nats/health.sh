#!/usr/bin/env bash
# usage: ./nats/health.sh
nats request health.PalindromeService hello | jq

