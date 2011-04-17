#! /bin/bash
# When you generate a new template, you ALWAYS get the same Project ID Guids ... this generates new ones

old_src_guid=0ABE71B2-5750-4F6D-96CD-3B97B80625C2
old_spec_guid=4AD000D9-C71E-47C0-AB38-0A4380C1D71B

new_src_guid=`./scripts/new-guid.exe`
new_spec_guid=`./scripts/new-guid.exe`

echo "Setting src  project ID to $new_src_guid"
echo "Setting spec project ID to $new_spec_guid"

grep -rl $old_src_guid .  | xargs sed -i "s/$old_src_guid/$new_src_guid/g"
grep -rl $old_spec_guid . | xargs sed -i "s/$old_spec_guid/$new_spec_guid/g"
